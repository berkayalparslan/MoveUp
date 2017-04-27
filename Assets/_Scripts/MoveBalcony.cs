using UnityEngine;
using System.Collections;

public class MoveBalcony : MonoBehaviour
{
    public SpawnBalconies parentBalcons;
    public FloorIncrementScript floorScript;

    void Start ()
    {

        parentBalcons = GameObject.Find("Balcons").GetComponent<SpawnBalconies>();

        floorScript = GameObject.Find("Floors").GetComponent<FloorIncrementScript>();
	
	}


	void Update ()
    {
	
	}


    void MoveUp()
    {

        Vector3 pos = new Vector3(transform.position.x, parentBalcons.posY, transform.position.z);
        transform.position = pos;

        //parentBalcons.posY++;
        floorScript.IncrementAllFloors();

        for(int i=0;i<parentBalcons.balconies.Count;i++)
        {
            parentBalcons.balconies[i].GetComponent<MoveBalcony>().MoveDown();
                
        }


    }
    

    void MoveDown()
    {
        Debug.Log("moved down");
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        transform.position = pos;


    }


}
