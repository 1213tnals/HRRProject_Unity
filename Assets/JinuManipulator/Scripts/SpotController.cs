using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QuadrupedRobot
{
    public class QuadController : MonoBehaviour
    {
        public enum RotationDirection { None = 0, Positive = 1, Negative = -1 };
        public enum ControlType { PositionControl };

        public ControlType control = ControlType.PositionControl;
        public float stiffness = 10000;
        public float damping = 100;
        public float forceLimit = 1000;
        public float speed = 5f; // Units: degree/s
        private ArticulationBody[] articulationChain;

        private ArticulationBody articulationBody;


        private void JointDriver(float[] jointStates)
        {
            var jointXDrive = articulationBody.xDrive;
            var jointYDrive = articulationBody.yDrive;
            var jointZDrive = articulationBody.zDrive;

            jointXDrive.target = jointStates[0] * Mathf.Deg2Rad;
            jointYDrive.target = jointStates[1] * Mathf.Deg2Rad;
            jointZDrive.target = jointStates[2] * Mathf.Deg2Rad;

            articulationBody.xDrive = jointXDrive;
            articulationBody.yDrive = jointYDrive;
            articulationBody.zDrive = jointZDrive;
        }
    }



    public class QuadJointController : MonoBehaviour
    {
        /*
        QuadController controller;

        public QuadController.RotationDirection direction;
        public QuadController.ControlType controltype;

        public float speed;
        public ArticulationBody joint;


        void Start()
        {
            direction = 0;
            controller = (QuadController)this.GetComponentInParent(typeof(QuadController));
            joint = this.GetComponent<ArticulationBody>();
            controller.UpdateControlType(this);
            speed = controller.speed;
        }
        void FixedUpdate()
        {
            speed = controller.speed;

            if (joint.jointType != ArticulationJointType.FixedJoint)
            {
                if (controltype == QuadController.ControlType.PositionControl)
                {
                    ArticulationDrive currentDrive = joint.xDrive;
                    float newTargetDelta = (int)direction * Time.fixedDeltaTime * speed;

                    if (joint.jointType == ArticulationJointType.RevoluteJoint)
                    {
                        if (joint.twistLock == ArticulationDofLock.LimitedMotion)
                        {
                            if (newTargetDelta + currentDrive.target > currentDrive.upperLimit)
                            {
                                currentDrive.target = currentDrive.upperLimit;
                            }
                            else if (newTargetDelta + currentDrive.target < currentDrive.lowerLimit)
                            {
                                currentDrive.target = currentDrive.lowerLimit;
                            }
                            else
                            {
                                currentDrive.target += newTargetDelta;
                            }
                        }
                        else
                        {
                            currentDrive.target += newTargetDelta;
                        }
                        joint.xDrive = currentDrive;
                    }

                    else if (joint.jointType == ArticulationJointType.PrismaticJoint)
                    {
                        if (joint.linearLockX == ArticulationDofLock.LimitedMotion)
                        {
                            if (newTargetDelta + currentDrive.target > currentDrive.upperLimit)
                            {
                                currentDrive.target = currentDrive.upperLimit;
                            }
                            else if (newTargetDelta + currentDrive.target < currentDrive.lowerLimit)
                            {
                                currentDrive.target = currentDrive.lowerLimit;
                            }
                            else
                            {
                                currentDrive.target += newTargetDelta;
                            }
                        }
                        else
                        {
                            currentDrive.target += newTargetDelta;

                        }
                        joint.xDrive = currentDrive;
                    }                    
                    
                    else if (joint.jointType == ArticulationJointType.SphericalJoint)
                    {
                        float newTargetDeltaX = (int)direction * Time.fixedDeltaTime * speed;
                        float newTargetDeltaY = (int)direction * Time.fixedDeltaTime * speed;
                        float newTargetDeltaZ = (int)direction * Time.fixedDeltaTime * speed;

                        ArticulationDrive XDrive = joint.xDrive;
                        ArticulationDrive YDrive = joint.yDrive;
                        ArticulationDrive ZDrive = joint.yDrive;                        

                        XDrive.target += newTargetDeltaX;
                        YDrive.target += newTargetDeltaY;
                        ZDrive.target += newTargetDeltaZ;

                        joint.xDrive = XDrive;  joint.yDrive = YDrive;  joint.zDrive = ZDrive;
                    }
                }
            }
        }
        */
    }
}