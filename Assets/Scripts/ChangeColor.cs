﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public string color;

	// Use this for initialization
	void Start () {
        if (color == "red")
            GetComponent<Renderer>().material.color = Color.red;
        else if (color == "blue")
            GetComponent<Renderer>().material.color = Color.blue;
        else if (color == "white")
            GetComponent<Renderer>().material.color = Color.white;
        else if (color == "yellow")
            GetComponent<Renderer>().material.color = Color.yellow;
        else if (color == "black"){
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
