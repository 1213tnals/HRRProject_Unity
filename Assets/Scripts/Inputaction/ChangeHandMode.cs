using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeHandMode : MonoBehaviour
{
    [SerializeField] public GameObject XR_Origin_Hand;
    [SerializeField] public GameObject XR_Origin_Laser;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        XR_Origin_Hand.SetActive(true);
        XR_Origin_Laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHMChanged(InputAction.CallbackContext context)
    {
        count++;
        if(count%2==1)
        {
            XR_Origin_Hand.SetActive(false);
            XR_Origin_Laser.SetActive(true);
        }
        else
        {
            XR_Origin_Hand.SetActive(true);
            XR_Origin_Laser.SetActive(false);
        }
    }
}
