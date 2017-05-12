using UnityEngine;
using System.Collections;


public class MoveCamera : MonoBehaviour
{
    private BallVisibility ballVisib;

    public GameObject ball;
    public GameStatus gameStatus;

    private Rigidbody2D ballRB;

    public float offset;
    public float lastPosY;
    public float movementLimit;


	void Start ()
    {
        ballVisib = GetComponent<BallVisibility>();
        ballRB = ball.GetComponent<Rigidbody2D>();
        offset = 2.5f;
	
	}
	

	void Update ()
    {

        //if(ball.GetComponent<Rigidbody2D>().velocity.y>=0)
        //{
            //Move();
        //}

        if( gameStatus.gameOver==false && ballRB.velocity.y >= -2.5f  )
        {
            Move();
        }
        
        //if(transform.rotation.x> maxRotaX)
        //{
        //    gameStatus.GameOver(true);
        //}
        //else
        //{
        //    Rotate();
        //}

    }


    void Move()
    {

        
        Vector3 pos= new Vector3(
            transform.position.x,
            ball.transform.position.y + offset,
            transform.position.z
            );
        
        transform.position = pos;



        lastPosY = transform.position.y;

    }


}
