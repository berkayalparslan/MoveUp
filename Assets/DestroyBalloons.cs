using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalloons : MonoBehaviour
{

    public List<GameObject> pool;
    public GameObject camera;
    public SpawnBalloons spawnBalloons;

    private BoxCollider2D col;

    public const int poolLimit=4;
    public const int offset = 10;

    void Start ()
    {

        col = GetComponent<BoxCollider2D>();
        SetPosition();

	}



    void Update ()
    {
        SetPosition();
	}


    private void OnTriggerEnter2D(Collider2D col)
    {

        if( col.CompareTag("Platform") )
        {

            pool.Add(col.gameObject);
            //SetPosition();

            if (pool.Count<poolLimit)
            {

                //SetPosition();
                DestroyThem();

            }

        }


    }


    private void DestroyThem()
    {
        
        for (int count=0;count<pool.Count;count++)
        {

            Destroy(pool[count]);

            spawnBalloons.DecreaseBalloonNum();
        }

        pool.Clear();

    }


    private void SetPosition()
    {
        float cameraPosY = camera.transform.position.y;

        if(cameraPosY-transform.position.y != 10)
        {
            transform.localPosition = new Vector3(transform.position.x, camera.transform.position.y - offset, transform.position.z);
        }
        
    }


}
