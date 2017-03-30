using UnityEngine;
using System.Collections;

public class SpawnBalconies : MonoBehaviour
{
    public GameObject balconyPrefab;
    public GameObject platformPrefab;
    public FloorScript floorScript;

    public int num=0;
    public int maxNumber;

    public float posY;
    public float platformPosY;

	void Start ()
    {

        num = GameObject.FindGameObjectsWithTag("Balcony").Length;

        maxNumber = 5;
        posY = 0;
        platformPosY = -0.25f;

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
            
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("Move");
            floorScript.IncrementAllFloors();

        }

    }
    

    void AddMovingPlatforms(GameObject obj)
    {
        Vector3 pos = new Vector3(0, platformPosY, transform.localPosition.z-0.75f);

        Instantiate(platformPrefab, pos, transform.rotation, obj.transform);

        platformPosY++;

    }


    void DecreaseNum()
    {
        num--;
    }


}
