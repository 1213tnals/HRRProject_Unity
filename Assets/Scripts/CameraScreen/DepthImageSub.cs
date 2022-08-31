using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using ImageMsg = RosMessageTypes.Sensor.CompressedImageMsg;

public class DepthImageSub : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    private Texture2D texture2D;
    private byte[] imageData;
    private bool isMessageReceived;


    void Start()
    {
        texture2D = new Texture2D(640, 480, TextureFormat.R16, false);

        meshRenderer.material = new Material(Shader.Find("Standard"));
        ROSConnection.GetOrCreateInstance().Subscribe<ImageMsg>("camera/depth/image_rect_raw/compressed", ReceiveMsg);
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


    void Update()
    {
        if (isMessageReceived)
        {
            ProcessMessage();
        }
    }
}


