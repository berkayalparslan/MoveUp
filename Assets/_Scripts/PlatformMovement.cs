using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{

    public GameStatus gameStatus;

    public float movingSpeed;
    public float leftBorder, rightBorder;

    public bool goingLeft;


    void Awake()
    {
        movingSpeed = 0.0f;

    }


	void Start ()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        leftBorder = -0.325f;
        rightBorder = 0.325f;

        SetRandomBeginDirection();
        SetRandomSpawnPosition();

        

	}
	

	void Update ()
    {

        if(gameStatus.gameOver==false)
        {
            MoveInTheRange();
        }

    }


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

        if ( Random.Range(0,1)==0 )
        {
            goingLeft = true;
        }

        else
        {
            goingLeft = false;
        }

    }

    
}
