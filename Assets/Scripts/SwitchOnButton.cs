using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnButton : MonoBehaviour {

    private bool isSwitchedOn = false;

    void OnMouseDown()
    {
        if (gameObject.GetComponent<Light>().enabled)
        {
            gameObject.GetComponent<Light>().enabled = false;
            isSwitchedOn = false;
        }
        else
        {
            gameObject.GetComponent<Light>().enabled = true;
            isSwitchedOn = true;
        }
    }

    public bool getIsSwitchedOn()
    {
        return isSwitchedOn;
    }
}
