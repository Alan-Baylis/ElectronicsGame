using System.Collections.Generic;
using UnityEngine;

//mellisa taylor

public class OnRun : MonoBehaviour {

    public GameObject light;

    private List<List<int>> arrayOfSystems;

	// Use this for initialization
	void Start () {
        arrayOfSystems = new List<List<int>>();
	}
	
	// Update is called once per frame
	void Update () {
		if(arrayOfSystems.Count != 0)
        {
            //foreach(List<int> o in arrayOfSystems)
            //{
            //    foreach(int b in o)
            //    {
            //        Debug.Log(b);
            //    }
            //}
        }
	}

    public void ActiveRunMode()
    {
        light.GetComponent<Light>().enabled = false;

        GameObject[,] componentMap = gameObject.GetComponent<ControlInputs>().componentMap;
        int tempI=0, tempJ=0, saveTempI, saveTempJ;
        bool systemEnded = false;
        bool firstTimeAfterBattery;
        bool findOnlyNoComponent;
        List<int> arrayOfActualSystem = new List<int>();
        for (int i = 0; i < componentMap.GetLength(0); i++)
        {
            for (int j = 0; j < componentMap.GetLength(1); j++)
            {
                if (componentMap[i, j] != null)
                {
                    if (componentMap[i, j].GetComponent<IDIntoComponent>().identifier == MyComponents.Battery)
                    {
                        firstTimeAfterBattery = true;
                        while (!systemEnded)
                        {
                            saveTempI = tempI;
                            saveTempJ = tempJ;
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
                                    arrayOfActualSystem.Add(tempI);
                                    arrayOfActualSystem.Add(tempJ);

                                    if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.wireVGND)
                                    {
                                        k = 3;
                                    }
                                    if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                                    {
                                        componentMap[tempI, tempJ].GetComponent<Light>().enabled = true;
                                        systemEnded = true;
                                        arrayOfSystems.Add(arrayOfActualSystem);
                                    }
                                    //componentMap[tempI, tempJ].GetComponent<Light>().enabled = true;
                                    //break;
                                }
                                //if (k == 3 && !firstTimeAfterBattery)
                                //{
                                //    tempI = saveTempI;
                                //    tempJ = saveTempJ;
                                //}
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
