using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    Transform Object2Follow;

    [SerializeField]
    GameObject TaskSpaceDefiner;

    void Update()
    {



        this.transform.position = new Vector3(Object2Follow.position.x, Object2Follow.position.y, Object2Follow.position.z);
        this.transform.rotation = new Quaternion(Object2Follow.rotation.x, Object2Follow.rotation.y, Object2Follow.rotation.z, Object2Follow.rotation.w);
    }
}
