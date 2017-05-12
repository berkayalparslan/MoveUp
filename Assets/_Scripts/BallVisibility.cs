using UnityEngine;
using System.Collections;

public class BallVisibility: MonoBehaviour
{

    private Camera cam;

    public GameObject ball;
    public GameStatus gameStatus;

    public Vector3 pos;


	void Start ()
    {

        cam = GetComponent<Camera>();
	
	}
	

	void Update ()
    {

        if (pos.y < 0)
        {
            gameStatus.GameOver(true);
            ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("gg wp gameover lol");

        }

        pos =cam.WorldToScreenPoint(ball.transform.position);

        
	

	}


}
