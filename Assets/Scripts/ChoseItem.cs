using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseItem : MonoBehaviour {

    public GameObject[] items;


	// Use this for initialization
	void Start () {
		
	}

    public void changeItem(string nameItem)
    {

        foreach(GameObject item in items)
        {
            if(item.name == nameItem)
                GetComponent<ControlInputs>().prefab = item;
        }
        //if (nameItem == "Image")
        //    GetComponent<ControlInputs>().prefab = items[0];
        //if (nameItem == "Image 1")
        //    GetComponent<ControlInputs>().prefab = items[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
