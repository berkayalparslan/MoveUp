using UnityEngine;
using System.Collections;

public class VerticalMovement : MonoBehaviour
{
    private Rigidbody rb;

    public bool isTouching;
    public float movementDistance;
    public GameObject ballHolder;

	void Start ()
    {

        rb = GetComponent<Rigidbody>();

        ballHolder = null;

        movementDistance = 5.0f;

        isTouching = false;

    }


    void Update()
    {

    }


	void FixedUpdate ()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.W) )
        {
            rb.AddForce(0, movementDistance, 0, ForceMode.Impulse);
        }

    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("touching the " + col.gameObject.name);

        if (col.gameObject.tag == "Balcony")
        {

            isTouching = true;
            

        }

        if(col.gameObject.tag=="Platform" )
        {
            ballHolder = col.transform.GetChild(0).gameObject;
            ballHolder.GetComponent<Collider>().enabled = true;

        }

    }


    //void OnTriggerStay(Collider col)
    //{

    //    if (col.gameObject.tag == "Platform")
    //    {
    //        ballHolder = col.gameObject.GetComponentInChildren<GameObject>();
    //        ballHolder.GetComponent<Collider>().enabled = true;
    //    }

    //}


    void OnTriggerExit(Collider col)
    {

        if( col.gameObject.tag == "Platform" )
        {

            //ballHolder = col.transform.GetChild(0).gameObject;
            //ballHolder.GetComponent<Collider>().enabled = false;
            //rb.WakeUp();

            //Destroy(col.gameObject);
            GameObject.Find("Balcons").SendMessage("DecreaseNum");
            
        }

    }


    public void Jump()
    {
        
        rb.AddForce(0, movementDistance, 0, ForceMode.Impulse);
        Debug.Log("fucking jump u fucking cunt");

    }


}
