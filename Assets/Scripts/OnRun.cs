using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mellisa taylor

public class OnRun : MonoBehaviour {

    public GameObject light;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActiveRunMode()
    {
        light.GetComponent<Light>().enabled = false;
        //MyComponents[,] componentMap = gameObject.GetComponent<ControlInputs>().componentMap;
        //int tempI, tempY;
        //for (int i = 0; i < componentMap.GetLength(0); i++)
        //{
        //    for (int j = 0; j < componentMap.GetLength(1); j++)
        //    {
        //        if (componentMap[i, j] == MyComponents.Battery)
        //        {
        //            if (componentMap[i + 1, y] == )
        //                foreach (Collider c in Physics.OverlapSphere(new Vector3(i * 2 + 1, 0.5f, j * 2 + 1), 1f))
        //                {
        //                    game
        //                }
        //        }
        //    }
        //}

        GameObject[,] componentMap = gameObject.GetComponent<ControlInputs>().componentMap;
        int tempI, tempY;
        for (int i = 0; i < componentMap.GetLength(0); i++)
        {
            for (int j = 0; j < componentMap.GetLength(1); j++)
            {
                if (componentMap[i, j] != null)
                {
                    if (componentMap[i, j].GetComponent<IDIntoComponent>().identifier == MyComponents.Battery)
                    {
                        if(componentMap[i-1,j] != null)
                        {
                            if (componentMap[i - 1, j] != null)
                            {
                                componentMap[i-1, j].GetComponent<Light>().enabled = true;
                            }
                        }
                        if (componentMap[i + 1, j] != null)
                        {
                            if (componentMap[i + 1, j] != null)
                            {
                                componentMap[i + 1, j].GetComponent<Light>().enabled = true;
                            }
                        }
                        if (componentMap[i, j-1] != null)
                        {
                            if (componentMap[i, j-1] != null)
                            {
                                componentMap[i, j-1].GetComponent<Light>().enabled = true;
                            }
                        }
                        if (componentMap[i, j+1] != null)
                        {
                            if (componentMap[i, j+1] != null)
                            {
                                componentMap[i, j+1].GetComponent<Light>().enabled = true;
                            }
                        }
                        //for (int k = -1; k < 2; k++)
                        //{
                        //    for (int l = 0; l < 2; l++)
                        //    {
                        //        if (componentMap[k, l] != null)
                        //        {
                        //            if (componentMap[k, l].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                        //            {
                        //                componentMap[k, l].GetComponent<Light>().enabled = true;
                        //                Debug.Log(k + " " + l + " : is a led !");
                        //            }
                        //            Debug.Log(k + " " + l + " : is not a led !");
                        //        }
                        //        Debug.Log(k + " " + l + " : is null !");
                        //    }
                        //}
                    }
                }
            }
        }
    }
}
