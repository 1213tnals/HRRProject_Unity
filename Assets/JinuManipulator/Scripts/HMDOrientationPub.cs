using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using PoseStampedMsg = RosMessageTypes.Geometry.PoseStampedMsg;
using Int32Msg = RosMessageTypes.Std.Int32Msg;    //+
using TransformStampedMsg = RosMessageTypes.Geometry.TransformStampedMsg;
using Unity.Ros;

public class HMDOrientationPub : MonoBehaviour
{
    [SerializeField] GameObject endEffector;
    [SerializeField] GameObject hmd;
    public string topicName = "unity/hmd_tf";
    public string topicNameHMD = "unity/hmd_tf";
    public string topicNameEE = "unity/hmd_tf";
    public string topicNameMS = "jinu_manipulator/mode_selector";
    public bool visionMode = false;
    public bool manipulationMode = false;

    ROSConnection m_Ros;
    ROSConnection m_Ros2;    //+

    private PoseStampedMsg hmdPose;
    private PoseStampedMsg eePose;
    private Int32Msg modeSelecter;    //+

    void Start()
    {
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<PoseStampedMsg>(topicName);
        m_Ros2 = ROSConnection.GetOrCreateInstance();    //+
        m_Ros.RegisterPublisher<Int32Msg>(topicNameMS);    //+

        hmdPose = new();
        eePose = new();
        modeSelecter = new();    //+
    }
    void Update()
    {

        if (visionMode)
        {
            modeSelecter.data = 3;    //+

            Pose hmdPoseRos = new(hmd.transform.localPosition.Unity2Ros(),
                                  hmd.transform.localRotation.Unity2Ros());

            hmdPose.pose.position = new();

            hmdPose.pose.orientation = new(hmdPoseRos.rotation.x,
                                           hmdPoseRos.rotation.y,
                                           hmdPoseRos.rotation.z,
                                           hmdPoseRos.rotation.w);

            m_Ros.Publish(topicNameHMD, hmdPose);
            m_Ros2.Publish(topicNameMS, modeSelecter);    //+
        }
        else if (manipulationMode)
        {
            modeSelecter.data = 5;    //+

            Pose eePoseRos = new(endEffector.transform.localPosition.Unity2Ros(),
                                  endEffector.transform.localRotation.Unity2Ros());

            eePose.pose.position = new(eePoseRos.position.x,
                                        eePoseRos.position.y,
                                        eePoseRos.position.z + 0.101f);

            eePose.pose.orientation = new(eePoseRos.rotation.x,
                                           eePoseRos.rotation.y,
                                           eePoseRos.rotation.z,
                                           eePoseRos.rotation.w);

            m_Ros.Publish(topicNameEE, eePose);
            m_Ros2.Publish(topicNameMS, modeSelecter);    //+
        }
    }
}
