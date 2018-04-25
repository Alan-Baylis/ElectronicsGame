using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnImageTouch : MonoBehaviour
{

    public GameObject character;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
		
	}

    public void changeColor()
    {
        GetComponent<Image>().color = Random.ColorHSV();
        character.GetComponent<ControlInputs>().prefab = prefab;
        //character.GetComponent<ChoseItem>().changeItem(gameObject.name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
