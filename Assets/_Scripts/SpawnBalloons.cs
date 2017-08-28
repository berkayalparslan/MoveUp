using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBalloons : MonoBehaviour
{

    public GameObject platformPrefab;

    //public List<GameObject> balconies;


    public int balloonNum=0;
    public int maxNumber;

    public float floorposY;
    public float platformPosY;

    public float movementCounter;
    public float movingSpeed;

    public float speedIncrement;
    public float platformIncrement;


    void Start ()
    {
        //balconies = new List<GameObject>();

        balloonNum = GameObject.FindGameObjectsWithTag("Platform").Length;

        maxNumber = 10;

        floorposY = 0;
        platformPosY = 0;

        movementCounter = 0;
        movingSpeed = 0.25f;

        //speedIncrement = 0.25f;
        speedIncrement = 0.15f;
        platformIncrement = 1.75f;


        //SetupFloors();
		AddBalloons();

    }


    void Update()
    {
		AddBalloons();
    }


    //void SetupFloors()
    //{

    //    while (floorNum < maxNumber)
    //    {
    //        GameObject obj;

    //        Vector3 pos = new Vector3(transform.position.x, floorposY, transform.position.z+1);
    //        obj= (GameObject) Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);

    //        //balconies.Add(obj);

    //        CreateMovingPlatforms(obj);

    //        floorNum++;
    //        floorposY+=floorIncrement;

    //    }

    //}


    void AddBalloons()
    {

        while (balloonNum < maxNumber)
        {

            GameObject obj;
			Vector3 pos = new Vector3(transform.position.x, platformPosY, transform.position.z);

			obj = (GameObject)Instantiate(platformPrefab, pos, transform.rotation, gameObject.transform);

            // check here for first floor
			if (balloonNum == 0)
			{

				obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;
				TriggerToCollider(obj.GetComponent<BoxCollider2D>());
                GameObject.Find("Ball").transform.SetParent(obj.transform);

			}

			else
			{
				obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;

			}

            balloonNum++;

			platformPosY+= platformIncrement;

			IncreaseMovSpeed();
        }

    }


    void TriggerToCollider(BoxCollider2D col)
    {
        col.isTrigger = false;
        col.offset = new Vector2(-0.015f, -0.055f);
        //col.size = new Vector2(0.13f, 0.13f);
        col.size = new Vector2(0.08f, 0.045f);
    }


    public void DecreaseBalloonNum()
    {
        balloonNum--;
    }


    void IncreaseMovSpeed()
    {
        movingSpeed += speedIncrement;
    }


}
