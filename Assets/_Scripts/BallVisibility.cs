using UnityEngine;
using System.Collections;

public class BallVisibility: MonoBehaviour
{

    private Camera cam;

    public GameObject ball;
    public GameSettings gameSettings;

    public Vector3 pos;


	void Start ()
    {
        cam = GetComponent<Camera>();
	
	}
	

	void Update ()
    {

        pos =cam.WorldToScreenPoint(ball.transform.position);

        if(pos.y<0)
        {
            gameSettings.GameOver(true);
            Debug.Log("gg wp gameover lol");

        }
	

	}


}
