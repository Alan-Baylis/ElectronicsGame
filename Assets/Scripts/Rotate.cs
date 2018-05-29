using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public int rotationX;
    public int rotationY;
    public int rotationZ;

    // Use this for initialization
    void Start () {
        gameObject.transform.Rotate(rotationX, rotationY, rotationZ);
	}
}
