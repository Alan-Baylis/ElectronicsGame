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

        GameObject[,] componentMap = gameObject.GetComponent<ControlInputs>().componentMap;
        int tempI=0, tempJ=0;
        bool systemEnded = false;
        bool firstTimeAfterBattery = true;
        bool findOnlyNoComponent;
        for (int i = 0; i < componentMap.GetLength(0); i++)
        {
            for (int j = 0; j < componentMap.GetLength(1); j++)
            {
                if (componentMap[i, j] != null)
                {
                    if (componentMap[i, j].GetComponent<IDIntoComponent>().identifier == MyComponents.Battery)
                    {
                        while (!systemEnded)
                        {
                            findOnlyNoComponent = true;
                            for (int k = 0; k < 4; k++)
                            {
                                switch (k)
                                {
                                    case 0:
                                        if (firstTimeAfterBattery)
                                        {
                                            tempI = i - 1;
                                            tempJ = j;
                                        } else
                                        {
                                            tempI--;
                                        }
                                        break;
                                    case 1:
                                        if(firstTimeAfterBattery)
                                        {
                                            tempI = i + 1;
                                            tempJ = j;
                                        } else
                                        {
                                            tempI += 2;
                                        }
                                        break;
                                    case 2:
                                        if (firstTimeAfterBattery)
                                        {
                                            tempI = i;
                                            tempJ = j - 1;
                                        } else
                                        {
                                            tempI--;
                                            tempJ--;
                                        }
                                        break;
                                    case 3:
                                        if (firstTimeAfterBattery)
                                        {
                                            tempI = i;
                                            tempJ = j + 1;
                                        } else
                                        {
                                            tempJ += 2;
                                        }
                                        break;
                                }
                                if (componentMap[tempI, tempJ] != null)
                                {
                                    findOnlyNoComponent = false;
                                    if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.wireVGND)
                                    {
                                        k = 3;
                                    }
                                    if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                                    {
                                        componentMap[tempI, tempJ].GetComponent<Light>().enabled = true;
                                        systemEnded = true;
                                    }
                                    //componentMap[tempI, tempJ].GetComponent<Light>().enabled = true;
                                    //break;
                                }
                                if (k == 3 && !firstTimeAfterBattery)
                                {
                                    tempJ--;
                                }
                                if(k==3 && findOnlyNoComponent)
                                {
                                    systemEnded = true;
                                }


                            }
                            firstTimeAfterBattery = false;
                        }
                    }
                }
            }
        }
    }


}
