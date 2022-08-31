using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hmdFollower : MonoBehaviour
{
    [SerializeField] GameObject Object2Follow;

    public bool visionMode = false;

    void Update()
    {
        if (visionMode)
        {            
            if (true)
            {
                this.transform.position = new Vector3(Object2Follow.transform.position.x, Object2Follow.transform.position.y, Object2Follow.transform.position.z);
                this.transform.rotation = new Quaternion(Object2Follow.transform.rotation.x, Object2Follow.transform.rotation.y, Object2Follow.transform.rotation.z, Object2Follow.transform.rotation.w);
            }
        }
    }
}
