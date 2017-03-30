using UnityEngine;
using System.Collections;

public class VerticalMovement : MonoBehaviour
{
    public float movingSpeed;

    public float leftBorder, rightBorder;

    public bool goingLeft;

	void Start ()
    {
        

        movingSpeed = 1.5f;

        leftBorder = -0.365f;
        rightBorder = 0.350f;

        SetRandomSpawnPosition();

        goingLeft = true;

	}
	

	void Update ()
    {

        MoveInTheRange();

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
