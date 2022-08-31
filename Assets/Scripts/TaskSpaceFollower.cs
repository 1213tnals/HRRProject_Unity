using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpaceFollower : MonoBehaviour
{
    [SerializeField] GameObject Object2Follow;
    [SerializeField] GameObject TaskSpaceDefiner;

    public bool manipulationMode = false;
    public bool triggerPressed = false;

    TaskSpaceTriggerActivate detector;

    private void Start()
    {
        detector = Object2Follow.GetComponent<TaskSpaceTriggerActivate>();
    }

    void Update()
    {
        if (manipulationMode)
        {            
            if (detector.inTaskSpace)
            {
                this.transform.position = new Vector3(Object2Follow.transform.position.x, Object2Follow.transform.position.y, Object2Follow.transform.position.z);
                this.transform.rotation = new Quaternion(Object2Follow.transform.rotation.x, Object2Follow.transform.rotation.y, Object2Follow.transform.rotation.z, Object2Follow.transform.rotation.w);

                triggerPressed = detector.isActivated;
            }
        }
    }
}
