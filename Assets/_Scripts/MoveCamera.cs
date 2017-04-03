using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public GameObject bground;

    public float movementHeight;


	void Start ()
    {
        movementHeight = 2.0f;
        
	
	}
	

	void Update ()
    {
	
	}


    void Move()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + movementHeight, transform.position.z);
        bground.transform.position = new Vector3(bground.transform.position.x, 
            bground.transform.position.y + movementHeight, 
            bground.transform.position.z);

    }


}
