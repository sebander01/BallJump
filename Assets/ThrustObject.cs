using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class ThrustObject : MonoBehaviour
{
    public GameObject pushItem;
    public GameObject pointFront;
    public GameObject pointRear;
    public float pushSpeed;
    public int delayS;
    public bool isLeft;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        Thrust();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private async void Thrust()
    {
        if (isLeft)
        {
            
            rb.AddForce(pointFront.transform.position, ForceMode.Impulse);

            await Task.Delay(delayS);

            rb.AddForce(pointRear.transform.position, ForceMode.Impulse);

            //}
            //else
            //{
            //    pushItem.transform.position = pointRear.transform.position;

            //    await Task.Delay(delayS);

            //    pushItem.transform.position = pointFront.transform.position;

            //    await Task.Delay(delayS);
        }
    }
}
