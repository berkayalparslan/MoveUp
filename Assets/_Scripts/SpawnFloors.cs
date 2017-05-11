using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFloors : MonoBehaviour
{

    public GameObject balconyPrefab;
    public GameObject platformPrefab;

    //public List<GameObject> balconies;


    public int floorNum=0;
    public int maxNumber;

    public float floorposY;
    public float platformPosY;

    public float movementCounter;
    public float movingSpeed;

    public float speedIncrement;
    public float floorIncrement;


    void Start ()
    {
        //balconies = new List<GameObject>();

        floorNum = GameObject.FindGameObjectsWithTag("Balcony").Length;

        maxNumber = 10;

        floorposY = 0;
        platformPosY = 0;

        movementCounter = 0;
        movingSpeed = 0.25f;

        //speedIncrement = 0.25f;
        speedIncrement = 0.15f;
        floorIncrement = 1.75f;


        //SetupFloors();
        AddFloors();

    }


    void Update()
    {
        AddFloors();
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


    void AddFloors()
    {

        while (floorNum < maxNumber)
        {

            GameObject obj;
            Vector3 pos = new Vector3(transform.position.x, floorposY, transform.position.z);

            obj = (GameObject)Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);
            CreateMovingPlatforms(obj);

            // check here for first floor
            

            floorNum++;
            floorposY+=floorIncrement;

        }

    }


    void CreateMovingPlatforms(GameObject gameobj)
    {
        GameObject obj;
        Vector2 pos = new Vector2(0, platformPosY);

        obj=(GameObject) Instantiate(platformPrefab, pos, transform.rotation, gameobj.transform);

        if (floorNum == 0)
        {

            obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;
            TriggerToCollider(obj.GetComponent<BoxCollider2D>());

        }

        else
        {
            obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;
            
        }

        platformPosY+= floorIncrement;

        IncreaseMovSpeed();

    }


    void TriggerToCollider(BoxCollider2D col)
    {
        col.isTrigger = false;
        col.offset = new Vector2(0, 0);
        //col.size = new Vector2(0.13f, 0.13f);
        col.size = new Vector2(0.19f, 0.11f);
    }


    public void DecreaseFloorNum()
    {
        floorNum--;
    }


    void IncreaseMovSpeed()
    {
        movingSpeed += speedIncrement;
    }


}
