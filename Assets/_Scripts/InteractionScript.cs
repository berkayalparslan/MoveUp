using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour
{



	void Start ()
    {
	
	}
	

	void Update ()
    {
	
	}


    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag=="Ball")
        {
            GetComponent<Collider>().enabled = false;
            Debug.Log("collider disabled");
        }

    }


    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag=="Ball")
        {
            GetComponent<Collider>().enabled = true;
            Debug.Log("collider enabled");
        }

    }



}
