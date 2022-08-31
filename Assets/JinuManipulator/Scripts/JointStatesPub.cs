using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using SetJointPositionRequest = RosMessageTypes.OpenManipulator.SetJointPositionRequest;
using SetJointPositionResponse = RosMessageTypes.OpenManipulator.SetJointPositionResponse;
using Kinematics = Unity.Ros.Manipulator.Kinematics;

public class JointStatesPub : MonoBehaviour
{
    [SerializeField] GameObject Manipulator;
    [Space]
    [SerializeField] string serviceNameTool = "goal_tool_control";
    [SerializeField] string serviceNameJoint = "goal_joint_space_path";
    [SerializeField] GameObject Target;
    [Space]
    public bool connectToRealRobot = false;

    // ROS Connector
    ROSConnection m_Ros;
    SetJointPositionRequest setJointPositionRequest;

    private string[] jointName;
    private double[] jointAngle;
    public float[] currentJointAngle = new float[6];

    private float awaitingResponseUntilTimestamp = -1;

    TaskSpaceFollower taskSpaceFollower;
    Kinematics kinematics;


    // Start is called before the first frame update
    void Start()
    {
        kinematics = Manipulator.GetComponent<Kinematics>();

        taskSpaceFollower = Target.GetComponent<TaskSpaceFollower>();

        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterRosService<SetJointPositionRequest, SetJointPositionResponse>(serviceNameTool);
        m_Ros.RegisterRosService<SetJointPositionRequest, SetJointPositionResponse>(serviceNameJoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > awaitingResponseUntilTimestamp)
        {
            if (taskSpaceFollower.triggerPressed)
            {
                jointName = new string[1];
                jointAngle = new double[1];

                jointName[0] = "gripper";
                jointAngle[0] = -0.01;
            }
            else
            {
                jointName = new string[1];
                jointAngle = new double[1];

                jointName[0] = "gripper";
                jointAngle[0] = 0.02;
            }

            setJointPositionRequest = new SetJointPositionRequest();
            setJointPositionRequest.joint_position.joint_name = jointName;
            setJointPositionRequest.joint_position.position = jointAngle;
            m_Ros.SendServiceMessage<SetJointPositionResponse>(serviceNameTool, setJointPositionRequest);

            awaitingResponseUntilTimestamp = Time.time + 0.5f;

            if (connectToRealRobot)
            {
                //currentJointAngle = new float[6];
                currentJointAngle = kinematics.GetQ();

                jointName = new string[6] { "joint1", "joint2", "joint3", "joint4", "joint5", "joint6" };
                jointAngle = new double[6] { 0, -1, 1.4, -0.3 + currentJointAngle[3], currentJointAngle[4], currentJointAngle[5] };

                setJointPositionRequest = new SetJointPositionRequest();
                setJointPositionRequest.joint_position.joint_name = jointName;
                setJointPositionRequest.joint_position.position = jointAngle;
                setJointPositionRequest.path_time = 0.2f;
                m_Ros.SendServiceMessage<SetJointPositionResponse>(serviceNameJoint, setJointPositionRequest);
            }
        }





    }
}
