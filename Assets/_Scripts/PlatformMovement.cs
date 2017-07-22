using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{

    public GameStatus gameStatus;

    public float movingSpeed;
    public float leftBorder, rightBorder;
    public float speedTimer;

    public bool goingLeft;


    void Awake()
    {
        movingSpeed = 0.0f;
        speedTimer = 0.0f;
    }


	void Start ()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        leftBorder = -0.3f;
        rightBorder = 0.3f;

        SetRandomBeginDirection();
        SetRandomSpawnPosition();

        

	}
	

	void Update ()
    {

        if(gameStatus.gameOver == false && gameStatus.GameStarted == true && gameStatus.gamePaused == false )
        {
            MoveInTheRange();
        }
        
        //if(GetComponent<Collider2D>().isTrigger==true)
        //{
        //    ChangeSpeed();
            
        //}
        //else
        //{
        //    movingSpeed = 0.25f;
        //}

    }


    //void ChangeSpeed()
    //{

    //    speedTimer += Time.deltaTime;

    //    if(speedTimer%2 == 0)
    //    {
    //        movingSpeed += 0.1f;
    //    }
    //    else
    //    {
    //        if( Random.Range(0,2) ==1 )
    //        {
    //            movingSpeed += Random.Range(-0.1f, 0.1f);
    //        }
                
    //    }

    //}


    void MoveInTheRange()
    {

        if (goingLeft)
        {
            transform.Translate(Vector3.left * movingSpeed* Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.right * movingSpeed* Time.deltaTime);
        }

        if (transform.localPosition.x < leftBorder)
        {
            goingLeft = false;
        }

        if (transform.localPosition.x > rightBorder)
        {
            goingLeft = true;
        }

    }


    void SetRandomSpawnPosition()
    {
        float posX = Random.Range(leftBorder, rightBorder);
        transform.position = new Vector3(posX, transform.position.y);

    }


    void SetRandomBeginDirection()
    {

        if ( Random.Range(0.0f,10.0f)< 5.5f )
        {
            goingLeft = true;
        }

        else
        {
            goingLeft = false;
        }

    }

    
}
