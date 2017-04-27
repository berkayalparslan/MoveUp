using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBalconies : MonoBehaviour
{
    public GameObject balconyPrefab;
    public GameObject platformPrefab;
    public GameObject triggerPrefab;

    public FloorIncrementScript floorScript;

    public List<GameObject> balconies;


    public int num=0;
    public int maxNumber;

    public float posY;
    public float platformPosY;
    public float movementCounter;
    public float movingSpeed;

    public float incrementValue = 0.25f;


    void Start ()
    {
        balconies = new List<GameObject>();

        num = GameObject.FindGameObjectsWithTag("Balcony").Length;

        maxNumber = 6;
        posY = 0;
        platformPosY = -0.25f;
        movementCounter = 0;
        movingSpeed = 0.0f;

        SetupBalconies();

    }


	void Update ()
    {
        //AddBalconies();

	}


    void SetupBalconies()
    {

        while (num < maxNumber)
        {
            GameObject obj;


            Vector3 pos = new Vector3(transform.position.x, posY,transform.position.z+1);
            obj= (GameObject) Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);

            balconies.Add(obj);

            CreateMovingPlatforms(obj);

            num++;
            posY++;

        }

    }
    

    void CreateMovingPlatforms(GameObject gameobj)
    {
        GameObject obj;
        Vector2 pos = new Vector2(0, platformPosY);

        obj=(GameObject) Instantiate(platformPrefab, pos, transform.rotation, gameobj.transform);

        if (num==0)
        {
            obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;
        }

        else
        {
            obj.GetComponent<PlatformMovement>().movingSpeed = movingSpeed;
            obj.GetComponent<Collider2D>().enabled = false;
        }

        
        CreateTriggers(obj);

        platformPosY++;

        IncreaseMovSpeed();

    }

    void CreateTriggers(GameObject obj)
    {
        GameObject triggerObj;
        Vector2 pos = new Vector2( 0, platformPosY);

        triggerObj = (GameObject) Instantiate(triggerPrefab, pos, transform.rotation, obj.transform);
        

    }

    void DecreaseNum()
    {
        num--;
    }


    void IncreaseMovSpeed()
    {
        movingSpeed += incrementValue;
    }




}
