using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eulerAngle : MonoBehaviour
{

    public GameObject dummyToFollow;
    public GameObject eulerDummy;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eulerDummy.transform.eulerAngles = dummyToFollow.transform.eulerAngles;
    }
}
