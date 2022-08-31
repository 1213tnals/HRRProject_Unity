using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using TfMsg = RosMessageTypes.Tf2.TFMessageMsg;
using Quat = RosMessageTypes.Geometry.QuaternionMsg;
using System;

public class TfSub : MonoBehaviour
{
    public Quaternion baseOrientation;

    public TfSub() { }

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<TfMsg>("/tf", Callback);
    }

    private void Callback(TfMsg tfMsg)
    {
        baseOrientation = ToUnityQuaternion(tfMsg.transforms[0].transform.rotation);
        //baseOrientation = ToQuaternion(tfMsg.transforms[0].transform.rotation);
    }

    private Quaternion ToQuaternion(Quat q) => new((float)q.x, (float)q.y, (float)q.z, (float)q.w);

    private Quaternion ToUnityQuaternion(Quat q) => new ((float)-q.y, (float)q.z, (float)q.x, (float)-q.w);
}
