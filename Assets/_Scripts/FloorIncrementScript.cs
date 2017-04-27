using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FloorIncrementScript : MonoBehaviour
{

    public GameObject prefabFloor;

    

    Vector3 pos;

    public int num;
    public int floorNum;
    public int recentFloor;

    public float height;

    void Start ()
    {
        num = 0;
        floorNum = 5;
        recentFloor = 0;

        pos = new Vector3(gameObject.transform.position.x, 0, 0);

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        height = gameObject.GetComponent<RectTransform>().rect.height / 5;

        AddFloors();
	
	}


    void Update ()
    {
        
    }


    void AddFloors()
    {

        for( num=0; num<floorNum; num++)
        {
            GameObject obj;
            obj =(GameObject) Instantiate(prefabFloor, pos, transform.rotation, gameObject.transform);

            IncrementFloor(obj);

            pos = new Vector3(gameObject.transform.position.x, pos.y + 256, 0);

        }

    }


    public void IncrementFloor(GameObject obj)
    {
        recentFloor++;
        obj.GetComponent<FloorTextScript>().score = recentFloor;

    }


    public void IncrementAllFloors()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Floor");

        for ( int i=0; i<objects.Length ;i++ )
        {
            objects[i].GetComponent<FloorTextScript>().score++;
        }

    }


}
