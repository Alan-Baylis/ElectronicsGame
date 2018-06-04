using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInputs : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
    public Canvas canvas;
    public Canvas menu;

    //public MyComponents[,] componentMap;
    public GameObject[,] componentMap;
    public int cellSizeX, cellSizeY;

    //protected Animator animator;

    // Use this for initialization
    void Start () {
        canvas.enabled = false;
        menu.enabled = false;
        //lui faire prendre la size du terrain
        //componentMap = new MyComponents[50,50];
        //for (int i = 0; i < 50; i++) {
        //    for (int j = 0; j < 50; j++)
        //        componentMap[i, j] = MyComponents.Nothing;
        //}
        componentMap = new GameObject[50, 50];
        for (int i = 0; i < 50; i++)
        {
                for (int j = 0; j < 50; j++)
                    componentMap[i, j] = null;
        }
        cellSizeX = 4;
        cellSizeY = 4;
	}

    public void Update()
    {
        if(Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.LeftShift))
        {
            DeleteComponent(Input.mousePosition);
        }
        else if (Input.GetKey(KeyCode.R) && Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit = RayFromCamera(Input.mousePosition, 1000.0f);
            Vector3 v = hit.point;
            if (hit.transform.tag == "Component")
            {
                hit.transform.Rotate(hit.transform.rotation.x, hit.transform.rotation.y + 90, hit.transform.rotation.z);
            }
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            PutComponent(Input.mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canvas.enabled)
                canvas.enabled = false;
            else
                canvas.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.enabled)
                menu.enabled = false;
            else
                menu.enabled = true;
        }
        
    }

    public void PutComponent(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        Vector3 v = hit.point;
        v.y = 1;
        //if (hit.transform.gameObject.tag != "Component")
        //{
            GameObject obj = GameObject.Instantiate(prefab, v, Quaternion.identity);
            Vector3 mousePos = obj.transform.position;

            //if (componentMap[(int)System.Math.Floor(mousePos.x / 2), (int)System.Math.Floor(mousePos.z / 2)] == MyComponents.Nothing)
            if (componentMap[(int)System.Math.Floor(mousePos.x / 2), (int)System.Math.Floor(mousePos.z / 2)] == null)
            {
                //componentMap[(int)System.Math.Floor(mousePos.x / 2), (int)System.Math.Floor(mousePos.z / 2)] = prefab.GetComponent<IDIntoComponent>().identifier;
                componentMap[(int)System.Math.Floor(mousePos.x / 2), (int)System.Math.Floor(mousePos.z / 2)] = obj;
                mousePos.x = (float)(2.0 * System.Math.Floor(mousePos.x / 2) + 1);
                mousePos.z = (float)(2.0 * System.Math.Floor(mousePos.z / 2) + 1);
                mousePos.y = obj.transform.position.y;
                obj.transform.position = mousePos;
            }
            else
                GameObject.Destroy(obj);


        //}
    }

    public void DeleteComponent(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        Vector3 v = hit.point;

        if(hit.transform.tag == "Component")
            GameObject.Destroy(hit.transform.gameObject);
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}
