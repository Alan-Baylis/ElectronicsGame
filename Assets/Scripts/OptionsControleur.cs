using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsControleur : MonoBehaviour {

    public Canvas options;
    public Canvas menu;

	// Use this for initialization
	void Start () {
        options.enabled = false;
	}
	
	// Update is called once per frame
	public void displayOptions () {
        options.enabled = true;
        menu.enabled = false;
    }

    public void hideOptions()
    {
        options.enabled = false;
        menu.enabled = true;
    }
}
