using UnityEngine;
using System;
using System.Collections.Generic;

namespace Unity.Ros.Manipulator
{
    public class ManipulatorController : MonoBehaviour
    {
        [Space]
        public bool gripperStateClosed = false;

        private float[] targetQ = new float[6];

        JointStatesSub jointStatesSub;

        public enum RotationDirection { None = 0, Positive = 1, Negative = -1 };
        public enum ControlType { PositionControl };

        public ControlType control = ControlType.PositionControl;
        public float stiffness = 10000;
        public float damping = 100;
        public float forceLimit = 1000;
        public float speed = 5f; // Units: degree/s
        private ArticulationBody[] articulationChain;
        private Kinematics kinematics;

        const int k_NumRobotJoints = 8;

        public static readonly string[] LinkNames =
            { "world/link1/link2", "/link3", "/link4", "/link5", "/link6", "/link7", "/gripper_link", "/gripper_link_sub" };

        // Robot Joints
        ArticulationBody[] m_JointArticulationBodies;

        TaskSpaceFollower taskSpaceFollower;

        public List<double> angles;
        public GameObject Target;

        private Vector3 lastPos;
        private Quaternion lastRot;

        void Start()
        {
            jointStatesSub = GetComponent<JointStatesSub>();

            kinematics = GetComponent<Manipulator.Kinematics>();

            articulationChain = this.GetComponentsInChildren<ArticulationBody>();
            foreach (ArticulationBody joint in articulationChain)
            {
                joint.gameObject.AddComponent<JointController>();
                ArticulationDrive currentDrive = joint.xDrive;
                currentDrive.forceLimit = forceLimit;
                joint.xDrive = currentDrive;
            }

            m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];
            var linkName = string.Empty;
            for (var i = 0; i < k_NumRobotJoints; i++)
            {
                linkName += LinkNames[i];
                m_JointArticulationBodies[i] = transform.Find(linkName).GetComponent<ArticulationBody>();
            }

            taskSpaceFollower = Target.GetComponent<TaskSpaceFollower>();
        }

        public void UpdateControlType(JointController joint)
        {
            joint.controltype = control;
            if (control == ControlType.PositionControl)
            {
                ArticulationDrive drive = joint.joint.xDrive;
                drive.stiffness = stiffness;
                drive.damping = damping;
                joint.joint.xDrive = drive;
            }
        }

        void Update()
        {
            gripperStateClosed = taskSpaceFollower.triggerPressed;
            GripperDriver(gripperStateClosed);

            targetQ = jointStatesSub.targetQ;

            JointDriver();
        }

        private void JointDriver()
        {
            for (var jointNum = 0; jointNum < 6; jointNum++)
            {
                var jointXDrive = m_JointArticulationBodies[jointNum].xDrive;
                jointXDrive.target = (float)(targetQ[jointNum] * 180 / 3.1415);
                m_JointArticulationBodies[jointNum].xDrive = jointXDrive;
            }
        }

        private void GripperDriver(bool isClosed)
        {
            if (isClosed)
            {
                var gripperDrive = m_JointArticulationBodies[6].xDrive;
                gripperDrive.target = 0.035f;
                m_JointArticulationBodies[6].xDrive = gripperDrive;

                var gripperSubDrive = m_JointArticulationBodies[7].xDrive;
                gripperSubDrive.target = 0.07f;
                m_JointArticulationBodies[7].xDrive = gripperSubDrive;
            }
            else
            {
                var gripperDrive = m_JointArticulationBodies[6].xDrive;
                gripperDrive.target = 0.0f;
                m_JointArticulationBodies[6].xDrive = gripperDrive;

                var gripperSubDrive = m_JointArticulationBodies[7].xDrive;
                gripperSubDrive.target = 0.0f;
                m_JointArticulationBodies[7].xDrive = gripperSubDrive;
            }
        }
    }
}
