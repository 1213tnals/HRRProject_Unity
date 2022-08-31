using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManipulationDefault : MonoBehaviour
{
    public GameObject image_menu;

    public void Start()
    {
        image_menu.SetActive(false);
    }
}
