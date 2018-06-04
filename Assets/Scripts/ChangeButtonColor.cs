using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {

    private int cpt = 0;

	public void changeButtonColorr()
    {
        if (cpt == 0)
        {
            gameObject.GetComponent<Image>().color = Color.grey;
            cpt++;
        } else
        {
            gameObject.GetComponent<Image>().color = Color.white;
            cpt--;
        }
    }
}
