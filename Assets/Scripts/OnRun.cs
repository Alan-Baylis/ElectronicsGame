using System.Collections.Generic;
using UnityEngine;

//mellisa taylor

public class OnRun : MonoBehaviour {

    //public GameObject light;

    //it's a list of list because you can have more that 1 battery
    private List<List<int>> arrayOfSystems;

	// Use this for initialization
	void Start () {
        arrayOfSystems = new List<List<int>>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("1");
        if (arrayOfSystems.Count != 0)
        {
            var hh = gameObject.GetComponent<ControlInputs>().componentMap;
            for (int i=0; i<arrayOfSystems.Count; i++)
            {
                //We read the j th system
                for(int j=0; j<arrayOfSystems[i].Count; j+=2)
                {
                    Debug.Log("j : " + j + " = " + arrayOfSystems[i][j] + " - " + arrayOfSystems[i][j+1] + " is " + hh[arrayOfSystems[i][j], arrayOfSystems[i][j+1]]);
                    //if the wire = null
                    if (hh[arrayOfSystems[i][j], arrayOfSystems[i][j + 1]] == null)
                    {
                        Debug.Log("1");
                        //Debug.Log(hh[arrayOfSystems[i][arrayOfSystems[i].Count - 4], arrayOfSystems[i][arrayOfSystems[i].Count - 3]]);
                        //Debug.Log(arrayOfSystems[i][arrayOfSystems[i].Count - 4] + "   " + arrayOfSystems[i][arrayOfSystems[i].Count - 3]);
                        //Debug.Log((arrayOfSystems[i].Count - 2) + "        " + (arrayOfSystems[i].Count - 1));
                        //if the last component (the one who have an effect) isn't null
                        for (int h = 0; h < arrayOfSystems[i].Count; h += 2)
                        {
                            if (hh[arrayOfSystems[i][h], arrayOfSystems[i][h+1]] != null)
                            {
                                if(hh[arrayOfSystems[i][h], arrayOfSystems[i][h+1]].GetComponent<IDIntoComponent>().identifier == MyComponents.wireVGND)
                                {
                                    //if the last one isn't null
                                    if (hh[arrayOfSystems[i][arrayOfSystems[i].Count - 2], arrayOfSystems[i][arrayOfSystems[i].Count - 1]] != null)
                                    {
                                        Debug.Log("2");
                                        //Debug.Log(hh[arrayOfSystems[i][arrayOfSystems[i].Count - 2], arrayOfSystems[i][arrayOfSystems[i].Count - 1]]);
                                        //if it's a LED
                                        if (hh[arrayOfSystems[i][arrayOfSystems[i].Count - 2], arrayOfSystems[i][arrayOfSystems[i].Count - 1]].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                                        {
                                            Debug.Log("3");
                                            gameObject.GetComponent<ControlInputs>().componentMap[arrayOfSystems[i][arrayOfSystems[i].Count - 2], arrayOfSystems[i][arrayOfSystems[i].Count - 1]].GetComponent<Light>().enabled = false;
                                        }
                                    }
                                }
                                else
                                {
                                    findAndSwithLEDInList(arrayOfSystems[i], false);
                                }
                            }
                        }
                    }
                }
            }
        }
	}

    public void ActiveRunMode()
    {
        //light.GetComponent<Light>().enabled = false;

        GameObject[,] componentMap = gameObject.GetComponent<ControlInputs>().componentMap;
        int tempI = 0, tempJ = 0; //position of the search
        bool systemEnded = false; //if the system ended
        bool firstTimeAfterBattery; //if it's the first search after finding a battery
        bool findOnlyNoComponent; //if he can't find a component
        bool isWireVGND = false; // if the wire found is V+GND or VGND
        bool isComponentOtherThanWireFound = false;  //if he find a component that isn't a wire (led,...)
        List<int> arrayOfActualSystem = new List<int>();
        for (int i = 0; i < componentMap.GetLength(0); i++)
        {
            for (int j = 0; j < componentMap.GetLength(1); j++)
            {
                //arrayOfActualSystem.Clear();
                if (componentMap[i, j] != null)
                {
                    if (componentMap[i, j].GetComponent<IDIntoComponent>().identifier == MyComponents.Battery)
                    {
                        firstTimeAfterBattery = true;
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
                                    if (!isInList(arrayOfActualSystem, tempI, tempJ))
                                    {
                                        if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.wireVGND)
                                        {
                                            findOnlyNoComponent = false;
                                            if (firstTimeAfterBattery)
                                                isWireVGND = true;
                                            if(isWireVGND) {
                                                k = 3;
                                                arrayOfActualSystem.Add(tempI);
                                                arrayOfActualSystem.Add(tempJ);
                                            }
                                            else {
                                                k = 3;
                                                systemEnded = true;
                                            }
                                        }
                                        else if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.wireV)
                                        {
                                            findOnlyNoComponent = false;
                                            if (firstTimeAfterBattery)
                                                isWireVGND = false;
                                            if (!isWireVGND && !isComponentOtherThanWireFound) {
                                                k = 3;
                                                arrayOfActualSystem.Add(tempI);
                                                arrayOfActualSystem.Add(tempJ);
                                            }
                                            else {
                                                k = 3;
                                                systemEnded = true;
                                            }
                                        }
                                        else if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.wireGND)
                                        {
                                            if (firstTimeAfterBattery)
                                            {
                                                isWireVGND = false;
                                            }
                                            else
                                            {
                                                findOnlyNoComponent = false;
                                                if (!isWireVGND && isComponentOtherThanWireFound)
                                                {
                                                    k = 3;
                                                    arrayOfActualSystem.Add(tempI);
                                                    arrayOfActualSystem.Add(tempJ);
                                                }
                                                //else
                                                //{
                                                //    k = 3;
                                                //    systemEnded = true;
                                                //}
                                            }
                                        }
                                        else if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                                        {
                                            findOnlyNoComponent = false;
                                            if (firstTimeAfterBattery || isWireVGND)
                                            {
                                                componentMap[tempI, tempJ].GetComponent<Light>().enabled = true;
                                                systemEnded = true;
                                                k = 3;
                                                arrayOfActualSystem.Add(tempI);
                                                arrayOfActualSystem.Add(tempJ);
                                                arrayOfSystems.Add(arrayOfActualSystem);
                                            } else if(!isWireVGND)
                                            {
                                                k = 3;
                                                arrayOfActualSystem.Add(tempI);
                                                arrayOfActualSystem.Add(tempJ);
                                                isComponentOtherThanWireFound = true;
                                            }
                                        }
                                        else if (componentMap[tempI, tempJ].GetComponent<IDIntoComponent>().identifier == MyComponents.Battery)
                                        {
                                            if(tempI == i && tempJ == j && !isWireVGND && isComponentOtherThanWireFound)
                                            {
                                                k = 3;
                                                systemEnded = true;
                                                findAndSwithLEDInList(arrayOfActualSystem, true);
                                                arrayOfSystems.Add(arrayOfActualSystem);
                                            }
                                        }
                                    }
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

    private bool isInList(List<int> list, int x, int y)
    {
        for(int i=0; i<list.Count; i += 2)
        {
            if(x == list[i] && y == list[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    private bool findAndSwithLEDInList(List<int> list, bool mustLightOn)
    {
        bool foundLED = false;
        var map = gameObject.GetComponent<ControlInputs>().componentMap;
        for (int i = 0; i < list.Count; i += 2)
        {
            if (map[list[i], list[i + 1]] != null)
            {
                if (map[list[i], list[i + 1]].GetComponent<IDIntoComponent>().identifier == MyComponents.LED)
                {
                    foundLED = true;
                    map[list[i], list[i + 1]].GetComponent<Light>().enabled = mustLightOn;
                }
            }
        }
        return foundLED;
    }


}
