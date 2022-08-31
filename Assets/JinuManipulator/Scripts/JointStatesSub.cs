using UnityEngine;
using JointStates = RosMessageTypes.Sensor.JointStateMsg;
using Unity.Robotics.ROSTCPConnector;


public class JointStatesSub : MonoBehaviour
{
    const int k_NumRobotJoints = 6;

    public static readonly string[] LinkNames =
        { "world/link1/link2", "/link3", "/link4", "/link5", "/link6", "/link7" };

    [SerializeField] GameObject m_JinuManipulator;
    [SerializeField] string m_TopicNameJointStates = "/joint_states";

    ArticulationBody[] m_JointArticulationBodies;

    ROSConnection m_Ros;

    public float[] targetQ = new float[6];

    void Start()
    {
        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];
        // m_JointArticulationBodies = this.GetComponentsInChildren<ArticulationBody>();

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += LinkNames[i];
            m_JointArticulationBodies[i] = m_JinuManipulator.transform.Find(linkName).GetComponent<ArticulationBody>();
        }

        m_Ros = ROSConnection.GetOrCreateInstance();

        m_Ros.Subscribe<JointStates>(m_TopicNameJointStates, JointStatesCallback);
    }

    private void JointStatesCallback(JointStates jointStates)
    {
        for (var joint = 0; joint < m_JointArticulationBodies.Length; joint++)
        {
            targetQ[joint] = (float)jointStates.position[joint];
        }
    }
}