using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Depth_Default : MonoBehaviour
{
    public GameObject defaultButton_RGB_ON;
    public GameObject defaultButton_RGB_OFF;
    public GameObject defaultButton_Depth_ON;
    public GameObject defaultButton_Depth_OFF;
    public GameObject defaultButton_IR_ON;
    public GameObject defaultButton_IR_OFF;
    public GameObject image_rgb;
    public GameObject image_depth;
    public GameObject image_ir;

    public void ScreenLoad()
    {
        defaultButton_RGB_ON.SetActive(false);
        defaultButton_RGB_OFF.SetActive(true);
        defaultButton_Depth_ON.SetActive(true);
        defaultButton_Depth_OFF.SetActive(false);
        defaultButton_IR_ON.SetActive(false);
        defaultButton_IR_OFF.SetActive(true);
        image_rgb.SetActive(false);
        image_depth.SetActive(true);
        image_ir.SetActive(false);
    }

}
