using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{


    public SpawnFloors spawnFloors;
    public GameStatus gameStatus;
    public ScoreScript scoreScript;
    public FollowTheBall triggerGameover;
    public FloorVisibility floorVisibility;

    public GameObject recentPlatform;
    public GameObject previousPlatform;

    private Rigidbody2D rb;

    public int movingCounter = 0;
    public float movementDistance;
    public float invokeTimer=1.0f;
    

	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();

        movementDistance = 6.5f;

        recentPlatform = null;
        previousPlatform = null;

        
    }


    void Update()
    {

        //if(transform.parent==null)
        //{
        //    transform.localScale = Vector3.one * 0.25f;
        //}

    }


	void FixedUpdate ()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && rb.velocity.normalized.y == 0 && gameStatus.gameOver==false || Input.GetKeyDown(KeyCode.W) )
        {
            rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);
            
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("touching the " + col.gameObject.name);

        //if (col.gameObject.tag == "Platform")
        //{
        //    //ballHolder = col.gameObject;
        //    //ballHolder.transform.GetComponent<Collider2D>().enabled = true;
        //    transform.SetParent(col.transform);
        //}

    }


    void OnTriggerStay2D(Collider2D col)
    {

        //if (col.gameObject.tag == "Platform" )
        //{
            
        //    col.transform.parent.GetComponent<MoveFloors>().CancelInvoke();
            

        //    //Vector3 pos = new Vector3(col.transform.parent.localPosition.x,
        //    //    col.transform.parent.localPosition.y + 0.1f,
        //    //    col.transform.parent.localPosition.z);

        //    //transform.position = pos;

        //}

    }


    void OnTriggerExit2D(Collider2D col)
    {

        if( col.gameObject.tag == "Platform" )
        {

            Debug.Log("leaving");

            TriggerToCollider(col.GetComponent<BoxCollider2D>());
            
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Platform")
        {

            recentPlatform = col.gameObject;

            scoreScript.IncreaseScore();

            transform.SetParent(col.transform);

            if(floorVisibility.isCalled==true)
            {
                floorVisibility.GetFloor(previousPlatform.transform.parent.gameObject);
            }
            
        }

    }


    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "Platform")
        {
            IdleSpeed(col.transform.GetComponent<PlatformMovement>());
        }
            
    }


    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "Platform")
        {
            previousPlatform = col.gameObject;
            

            transform.parent = null;

            if(movingCounter>4)
            {
                //col.transform.parent.GetComponent<MoveFloors>().Invoke("MoveUp", invokeTimer);
                movingCounter = 0;
            }
            

            ColliderToTrigger(col.gameObject.GetComponent<BoxCollider2D>());

            col.transform.GetComponent<PlatformMovement>().movingSpeed += spawnFloors.speedIncrement;

            if(floorVisibility.isCalled==false)
            {

                floorVisibility.GetFloor(col.gameObject.transform.parent.gameObject);
                floorVisibility.isCalled = true;

            }
            

        }

    }


    //method to check if ball has changed the floor or not
    bool JumpedToNext(GameObject recent,GameObject prev)
    {

        if(recent==prev)
        {
            return false;
        }

        else
        {
            movingCounter++;
            return true;
        }

    }


    public void Jump()
    {
        
        rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);
        Debug.Log("fucking jump u fucking cunt");

    }


    //method to switch Trigger to Box Collider
    public void TriggerToCollider(BoxCollider2D col)
    {
        col.isTrigger = false;
        col.offset = new Vector2(0, 0);
        //col.size = new Vector2(0.13f, 0.13f);
        col.size = new Vector2(0.19f, 0.11f);
    }


    //method to switch Box Collider to Trigger
    public void ColliderToTrigger(BoxCollider2D col)
    {
        col.isTrigger = true;
        col.offset = new Vector2(0, 0.15f);
        col.size = new Vector2(1, 0.16f);
        Debug.Log("collider to trigger");
    }



    void IdleSpeed(PlatformMovement platformMov)
    {
        platformMov.movingSpeed += 0.001f;
    }


}
