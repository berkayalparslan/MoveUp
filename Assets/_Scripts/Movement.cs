using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    
    public bool isTouching;


	void Start ()
    {
        
        rb = GetComponent<Rigidbody>();
        
        isTouching = true;

    }

    void Update()
    {

        

    }


	void FixedUpdate ()
    {

        if( isTouching ==true )
        {
            rb.Sleep();
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, 10, 0, ForceMode.Impulse);
        }

    }


    void OnTriggerEnter(Collider col)
    {

        if( col.gameObject.tag == "Balcony" )
        {
            Debug.Log("touching the " + col.gameObject.name);
            isTouching = true;

        }

    }



    void OnTriggerExit(Collider col)
    {

        if( col.gameObject.tag == "Balcony" )
        {

            isTouching = false;
            //rb.WakeUp();
            Destroy(col.gameObject);
            GameObject.Find("Balcons").SendMessage("DecreaseNum");          
            
        }


    }

}
