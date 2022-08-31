using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject image_menu;

    int count = 0;

    public void ScreenLoad()
    {
        count++;

        if (count % 2 == 1)
        {
            image_menu.SetActive(true);
        }
        else
        {
            image_menu.SetActive(false);
        }
    }

}
