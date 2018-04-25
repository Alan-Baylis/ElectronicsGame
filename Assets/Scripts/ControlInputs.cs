using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInputs : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
    public Canvas canvas;

    //protected Animator animator;

    // Use this for initialization
    void Start () {
        canvas.enabled = false;
	}

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            PutCoin(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canvas.enabled)
                canvas.enabled = false;
            else
                canvas.enabled = true;

        }
        //if(Input.GetKey(KeyCode.Z))
        //{
        //    transform.Translate(0, 0, 10 * Time.deltaTime);
        //    animator.SetBool("Moving", true);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0, 0, -10 * Time.deltaTime);
        //    animator.SetBool("Moving", true);
        //}
        //else
        //{
        //    animator.SetBool("Moving", false);
        //}
    }

    public void PutCoin(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        Vector3 v = hit.point;
        v.y = 1;
        GameObject.Instantiate(prefab, v, Quaternion.identity);
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}
