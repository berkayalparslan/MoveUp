using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{

    public GameSettings gameSettings;

    public float movingSpeed;
    public float leftBorder, rightBorder;

    public bool goingLeft;


    void Awake()
    {
        movingSpeed = 0.0f;

    }


	void Start ()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        leftBorder = -0.213f;
        rightBorder = 0.220f;

        SetRandomSpawnPosition();

        goingLeft = true;

	}
	

	void Update ()
    {

        if(gameSettings.gameOver==false)
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

    
}
