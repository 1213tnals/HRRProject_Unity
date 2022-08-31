using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TaskSpaceTriggerActivate : MonoBehaviour
{
    [SerializeField] InputActionReference controllerActionTrigger;

    private float _triggerValue;


    public bool isActivated = false;
    public bool inTaskSpace = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TaskSpaceDefiner")
        {
            inTaskSpace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "TaskSpaceDefiner")
        {
            inTaskSpace = false;
        }
    }

    public void TriggerPress(InputAction.CallbackContext obj)
    {
        SetTriggerValue("Pinch", obj.ReadValue<float>());
    }

    private void SetTriggerValue(string v1, float v2)
    {
        throw new NotImplementedException();
    }

    public void SetTriggerTrue() => isActivated = true;
    public void SetTriggerFalse() => isActivated = false;
}
