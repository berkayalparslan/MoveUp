using UnityEngine;
using System.Collections;

public class SpawnBalconies : MonoBehaviour
{
    public GameObject balconyPrefab;
    public FloorScript floorScript;

    public int num=0;
    public int maxNumber;

    public float posY;

	void Start ()
    {

        num = GameObject.FindGameObjectsWithTag("Balcony").Length;

        maxNumber = 5;
        posY = 0;

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
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);
            Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);

            num++;
            posY++;
        }

    }


    void AddBalconies()
    {

        while (num < maxNumber)
        {
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);
            Instantiate(balconyPrefab, pos, transform.rotation, gameObject.transform);

            num++;
            posY++;
            
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("Move");
            floorScript.IncrementAllFloors();

        }

    }

    void DecreaseNum()
    {
        num--;
    }


}
