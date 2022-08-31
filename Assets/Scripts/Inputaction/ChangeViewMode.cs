using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeViewMode : MonoBehaviour
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

    int count = 0;

    void Update()
    {

    }

    public void OnVMChanged(InputAction.CallbackContext context)
    {
        count++;
        defaultButton_RGB_ON.SetActive(false);
        defaultButton_RGB_OFF.SetActive(false);
        defaultButton_Depth_ON.SetActive(false);
        defaultButton_Depth_OFF.SetActive(false);
        defaultButton_IR_ON.SetActive(false);
        defaultButton_IR_OFF.SetActive(false);


        if (count % 9 == 1 || count % 9 == 2 || count % 9 == 3)
        {
            image_rgb.SetActive(false);
            image_depth.SetActive(true);
            image_ir.SetActive(false);
            defaultButton_RGB_ON.SetActive(false);
            defaultButton_RGB_OFF.SetActive(true);
            defaultButton_Depth_ON.SetActive(true);
            defaultButton_Depth_OFF.SetActive(false);
            defaultButton_IR_ON.SetActive(false);
            defaultButton_IR_OFF.SetActive(true);
        }
        else if (count % 9 == 4 || count % 9 == 5 || count % 9 == 6)
        {
            image_rgb.SetActive(false);
            image_depth.SetActive(false);
            image_ir.SetActive(true);
            defaultButton_RGB_ON.SetActive(false);
            defaultButton_RGB_OFF.SetActive(true);
            defaultButton_Depth_ON.SetActive(false);
            defaultButton_Depth_OFF.SetActive(true);
            defaultButton_IR_ON.SetActive(true);
            defaultButton_IR_OFF.SetActive(false);
        }
        else
        {
            image_rgb.SetActive(true);
            image_depth.SetActive(false);
            image_ir.SetActive(false);
            defaultButton_RGB_ON.SetActive(true);
            defaultButton_RGB_OFF.SetActive(false);
            defaultButton_Depth_ON.SetActive(false);
            defaultButton_Depth_OFF.SetActive(true);
            defaultButton_IR_ON.SetActive(false);
            defaultButton_IR_OFF.SetActive(true);
        }
    }
}
