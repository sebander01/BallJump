using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    public GameObject arm;
    public GameObject rotatePoint;
    public float spinspeed;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arm.transform.RotateAround(rotatePoint.transform.position,rotatePoint.transform.up, spinspeed);
    }
}
