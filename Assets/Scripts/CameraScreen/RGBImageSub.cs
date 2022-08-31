using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using ImageMsg = RosMessageTypes.Sensor.CompressedImageMsg;

public class RGBImageSub : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    private Texture2D texture2D;
    private byte[] imageData;
    private bool isMessageReceived;


    void Start()
    {
        texture2D = new Texture2D(640, 480, TextureFormat.RGB24, false);

        meshRenderer.material = new Material(Shader.Find("Standard"));
        ROSConnection.GetOrCreateInstance().Subscribe<ImageMsg>("camera/color/image_raw/compressed", ReceiveMsg);
    }


    void ReceiveMsg(ImageMsg imageMsg)
    {
        imageData = imageMsg.data;
        isMessageReceived = true;
    }

    private void ProcessMessage()
    {
        texture2D.LoadImage(imageData);
        texture2D.Apply();
        meshRenderer.material.SetTexture("_MainTex", texture2D);
        isMessageReceived = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isMessageReceived)
        {
            ProcessMessage();
        }
    }
}
