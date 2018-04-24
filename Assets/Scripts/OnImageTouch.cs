using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnImageTouch : MonoBehaviour
{

    public GameObject character;

	// Use this for initialization
	void Start () {
		
	}

    public void changeColor()
    {
        GetComponent<Image>().color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
