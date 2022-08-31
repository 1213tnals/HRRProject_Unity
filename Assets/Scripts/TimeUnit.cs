using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeUnit : MonoBehaviour
{
    [SerializeField] Text time;

    // Update is called once per frame
    void Update()
    {
        time.text = DateTime.Now.ToString();
    }
}
