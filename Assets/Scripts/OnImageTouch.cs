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
        GetComponent<Image>().color = Color.white;
        character.GetComponent<ControlInputs>().prefab = prefab;
        //character.GetComponent<ChoseItem>().changeItem(gameObject.name);
    }

    public void resetColor()
    {
        GetComponent<Image>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
