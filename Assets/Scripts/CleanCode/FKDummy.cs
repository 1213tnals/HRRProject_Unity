using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Ros.Manipulator
{
    public class FKDummy : MonoBehaviour
    {
        public GameObject dummy;

        private readonly float smooth = 10.0f;
        private Kinematics kinematics;
        private float x, y, z;
        private Matrix4x4 EEPose;
        private Quaternion quat;
        private List<Matrix4x4> hs;

        void Start()
        {
            kinematics = (Kinematics)this.GetComponent(typeof(Kinematics));
        }

        void Update()
        {
            hs = kinematics.GetFK();

            EEPose = hs[6];

            quat = ToUnity(EEPose.rotation);

            x = EEPose[0, 3];
            y = EEPose[1, 3];
            z = EEPose[2, 3];

            dummy.transform.localPosition = new Vector3(x, y, z).Ros2Unity();
            dummy.transform.localRotation = Quaternion.Slerp(dummy.transform.localRotation, quat, Time.deltaTime * smooth);
        }

        private Quaternion ToUnity(Quaternion q) => new(-q.y, q.z, q.x, -q.w);
    }
}

