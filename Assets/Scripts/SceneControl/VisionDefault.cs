using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VisionDefault : MonoBehaviour
{
    [SerializeField]
    public GameObject defaultButton_RGB_ON;
    public GameObject defaultButton_RGB_OFF;
    public GameObject defaultButton_Depth_ON;
    public GameObject defaultButton_Depth_OFF;
    public GameObject defaultButton_IR_ON;
    public GameObject defaultButton_IR_OFF;
    public GameObject image_rgb;
    public GameObject image_depth;
    public GameObject image_ir;
    public GameObject image_menu;

    public void Start()
    {
        defaultButton_RGB_ON.SetActive(true);
        defaultButton_RGB_OFF.SetActive(false);
        defaultButton_Depth_ON.SetActive(false);
        defaultButton_Depth_OFF.SetActive(true);
        defaultButton_IR_ON.SetActive(false);
        defaultButton_IR_OFF.SetActive(true);
        image_rgb.SetActive(true);
        image_depth.SetActive(false);
        image_ir.SetActive(false);
        image_menu.SetActive(false);
    }
}

