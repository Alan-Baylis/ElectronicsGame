using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopulationGrid : MonoBehaviour
{

    public GameObject[] prefab;

    void Start()
    {
        //newObj = new GameObject[numberToCreate];
        Populate();
    }

    void Populate()
    {
        // Create GameObject instance
        GameObject newObj;

        for (int i = 0; i < prefab.Length; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab[i], transform);

            // Randomize the color of our image
            newObj.GetComponent<Image>().color = Random.ColorHSV();
        }

    }
}
