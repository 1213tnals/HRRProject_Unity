using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionMode : MonoBehaviour
{
    public GameObject image_rgb;
    public GameObject image_depth;
    public GameObject image_ir;
    public GameObject image_UI;

    public GameObject Home_UI;

    public void ScreenLoad()
    {
        image_rgb.SetActive(true);
        image_depth.SetActive(false);
        image_ir.SetActive(false);
        image_UI.SetActive(true);

        Home_UI.SetActive(false);
    }
}
