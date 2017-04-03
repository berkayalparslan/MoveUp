using UnityEngine;
using System.Collections;

public class SpawnBalconies : MonoBehaviour
{
    public GameObject balconyPrefab;
    public GameObject platformPrefab;
    public GameObject ballHolderPrefab;

    public FloorScript floorScript;

    public int num=0;
    public int maxNumber;

    public float posY;
    public float platformPosY;
    public float movementCounter;

	void Start ()
    {

        num = GameObject.FindGameObjectsWithTag("Balcony").Length;

        maxNumber = 5;
        posY = 0;
        platformPosY = -0.25f;
        movementCounter = 0;

        SetupBalconies();

    }


	void Update ()
    {
        AddBalconies();

	}


    void SetupBalconies()
    {

        while (num < maxNumber)
        {
            GameObject obj;


            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);
            obj= (GameObject) Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);

            AddMovingPlatforms(obj);
            

            num++;
            posY++;

        }

    }


    void AddBalconies()
    {

        while (num < maxNumber)
        {
            GameObject obj;
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);
            obj= (GameObject) Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);
            AddMovingPlatforms(obj);

            num++;
            posY++;
            movementCounter++;
            if(movementCounter==2)
            {
                GameObject.FindGameObjectWithTag("MainCamera").SendMessage("Move");
                movementCounter = 0;
                
            }

            floorScript.IncrementAllFloors();


        }

    }
    

    void AddMovingPlatforms(GameObject gameobj)
    {
        GameObject obj;
        Vector3 pos = new Vector3(0, platformPosY, transform.localPosition.z-0.75f);

        obj=(GameObject) Instantiate(platformPrefab, pos, transform.rotation, gameobj.transform);

        AddBallHolders(obj);

        platformPosY++;

    }

    void AddBallHolders(GameObject obj)
    {
        GameObject ballHolder;
        Vector3 pos = new Vector3( 0, platformPosY, transform.localPosition.z - 0.75f );

        ballHolder = (GameObject) Instantiate(ballHolderPrefab, pos, transform.rotation, obj.transform);
        if (num != 0)
        {
            ballHolder.GetComponent<Collider>().enabled = false;
        }
        

    }

    void DecreaseNum()
    {
        num--;
    }




}
