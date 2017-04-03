using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    public GameObject ball;

    void Start ()
    {
        ball = GameObject.Find("ball");

        //ball.transform.position = new Vector3(0, -0.065f, 0);
	
	}


    void Update ()
    {
	
	}


}
