using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class Depth : MonoBehaviour
{
    public GameObject defaultButton;
    public GameObject image_rgb;
    public GameObject image_depth;
    public GameObject image_ir;

    public void ScreenLoad()
    {
        defaultButton.SetActive(false);
        image_rgb.SetActive(false);
        image_depth.SetActive(true);
        image_ir.SetActive(false);
    }
}
