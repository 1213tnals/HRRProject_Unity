using UnityEngine;

namespace Unity.Ros.Manipulator
{
    public class JointController : MonoBehaviour
    {
        ManipulatorController controller;

        public ManipulatorController.RotationDirection direction;
        public ManipulatorController.ControlType controltype;

        public float speed;
        public ArticulationBody joint;


        void Start()
        {
            direction = 0;
            controller = (ManipulatorController)this.GetComponentInParent(typeof(ManipulatorController));
            joint = this.GetComponent<ArticulationBody>();
            controller.UpdateControlType(this);
            speed = controller.speed;
        }

        /*
        void FixedUpdate()
        {
            speed = controller.speed;



            if (joint.jointType != ArticulationJointType.FixedJoint)
            {
                if (controltype == ManipulatorController.ControlType.PositionControl)
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
                    }

                    joint.xDrive = currentDrive;

                }
            }
        }
        */
    }
}

