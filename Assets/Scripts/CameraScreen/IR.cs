using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IR : MonoBehaviour
{
    public GameObject defaultButton;
    public GameObject image_rgb;
    public GameObject image_depth;
    public GameObject image_ir;

    public void ScreenLoad()
    {
        defaultButton.SetActive(false);
        image_rgb.SetActive(false);
        image_depth.SetActive(false);
        image_ir.SetActive(true);
    }
}
