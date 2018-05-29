using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNightDay : MonoBehaviour {

    public Light sun;

	public void swapNightDay()
    {
        if (sun.GetComponent<Light>().enabled)
            sun.GetComponent<Light>().enabled = false;
        else
            sun.GetComponent<Light>().enabled = true;
    }
}
