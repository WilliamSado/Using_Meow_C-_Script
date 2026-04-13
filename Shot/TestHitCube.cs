using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHitCube : MonoBehaviour {

    Camera main;
    public GameObject plane;
    Ray ray;
    Vector3 mousePos;
    public Rigidbody bullet_prefab;
	// Use this for initialization
	void Start () {
        main = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButton(0))
        {
            float mousex = Input.GetAxis("Mouse X");
            main.transform.RotateAround(plane.transform.position, Vector3.up, mousex);
        }
        /*if (Input.GetMouseButton(1))
        {
            float mousex = Input.GetAxis("Mouse X");
            main.transform.RotateAround(plane.transform.position, Vector3.up, mousex);
        }
        if (Input.GetMouseButton(2))
        {
            float mousex = Input.GetAxis("Mouse X");
            main.transform.RotateAround(plane.transform.position, Vector3.up, mousex);
        }*/
        ray = main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        /*if (Input.GetMouseButtonDown(1))
        {
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(2))
        {
            mousePos = Input.mousePosition;
        }*/

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 current_mousePos = Input.mousePosition;
            if (Mathf.Abs(current_mousePos.x - mousePos.x) < 50)
            {
                Rigidbody clone = Instantiate(bullet_prefab, ray.GetPoint(10), Quaternion.identity);
                clone.AddForce(ray.direction * 300f, ForceMode.Impulse);
            }
        }
/*      if (Input.GetMouseButtonUp(1))
        {
            Vector3 current_mousePos = Input.mousePosition;
            if (Mathf.Abs(current_mousePos.x - mousePos.x) < 50)
            {
                Rigidbody clone = Instantiate(bullet_prefab, ray.GetPoint(10), Quaternion.identity);
                clone.AddForce(ray.direction * 50f, ForceMode.Impulse);
            }
        }
        if (Input.GetMouseButtonUp(2)
        {
            Vector3 current_mousePos = Input.mousePosition;
            if (Mathf.Abs(current_mousePos.x - mousePos.x) < 50)
            {
                Rigidbody clone = Instantiate(bullet_prefab, ray.GetPoint(10), Quaternion.identity);
                clone.AddForce(ray.direction * 50f, ForceMode.Impulse);
            }
        }*/
    }
}
