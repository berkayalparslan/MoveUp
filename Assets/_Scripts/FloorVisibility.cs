using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorVisibility : MonoBehaviour
{

    private Camera cam;

    public List<GameObject> destroyPool;
    public Vector3 pos;
    //public GameObject floor;
    public SpawnFloors spawnFloors;

    public bool isCalled;
    public bool clearPool;
    public int poolLimit;

    void Start ()
    {

        cam = GetComponent<Camera>();
        //floor = null;
        pos = Vector3.zero;
        isCalled = false;
        clearPool = false;
        poolLimit = 2;
	
	}
	
	
	void Update ()
    {

        //if(isCalled)
        //{
        //    pos = cam.WorldToScreenPoint(floor.transform.position);
        //}
        

        //if(pos.y<0)
        //{
        //    DestroyFloor(floor);
        //}

        if(clearPool==true)
        {
            DestroyFloors();
        }

    }

    
    public void GetFloor(GameObject obj)
    {
        //floor = obj;
        destroyPool.Add(obj);

        if(destroyPool.Count>poolLimit)
        {

            DestroyFloors();
            //isCalled = true;
            clearPool = true;
        }
        else
        {
            clearPool = false;
        }
        

    }


    void DestroyFloors()
    {

        for(int i=0;i<destroyPool.Count;i++)
        {

            Destroy(destroyPool[i]);
            destroyPool.Remove(destroyPool[i]);

            spawnFloors.DecreaseFloorNum();

        }
        
    }




    

}
