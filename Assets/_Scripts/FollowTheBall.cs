using UnityEngine;
using System.Collections;

public class FollowTheBall : MonoBehaviour
{

    public GameObject ball;

    public float distance;


	void Start ()
    {

        distance = 2.0f;
	
	}
	

	void Update ()
    {

	
	}


    public void SetPosition(GameObject obj)
    {
        Vector3 pos = new Vector3(
            obj.transform.position.x, 
            obj.transform.position.y - distance, 
            obj.transform.position.z);

        transform.position = pos;

        Debug.Log("follow the ball script ended the game");
    }



}
