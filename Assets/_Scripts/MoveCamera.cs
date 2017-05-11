using UnityEngine;
using System.Collections;


public class MoveCamera : MonoBehaviour
{

    public GameObject ball;
    public GameStatus gameStatus;

    public float offset;
    public float lastPosY;


	void Start ()
    {

        offset = 2.5f;
	
	}
	

	void Update ()
    {

        //if(ball.GetComponent<Rigidbody2D>().velocity.y>=0)
        //{
            //Move();
        //}

        if(gameStatus.gameOver==false && ball.GetComponent<Rigidbody2D>().velocity.y >= 0)
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
        
        transform.position = new Vector3(
            transform.position.x, 
            ball.transform.position.y+offset, 
            transform.position.z
            );

        lastPosY = transform.position.y;

    }


}
