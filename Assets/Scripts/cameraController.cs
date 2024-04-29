using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public float sensitivity = 200;
    public float angleMax = 45;
    public float angleMin = 60;

    private float angle, newAngle; 

    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        newAngle-= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        newAngle=Mathf.Clamp(newAngle, angleMin, angleMax);
 
       transform.Rotate(new Vector3(newAngle-angle, 0, 0));
        angle = newAngle;
        //Debug.Log(angle);


    }
}
