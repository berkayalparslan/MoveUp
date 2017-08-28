using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{


    public SpawnBalloons spawnBalloons;
    public GameStatus gameStatus;
    public ScoreScript scoreScript;
    public FollowTheBall triggerGameover;

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

        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began 
            && rb.velocity.normalized.y == 0 && gameStatus.gameOver==false && gameStatus.gameStarted==true 
            && gameStatus.gamePaused==false || Input.GetKeyDown(KeyCode.W) && gameStatus.gameStarted == true 
            && rb.velocity.normalized.y == 0 )
        {
            rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);

            //GONNA UNCOMMENT HERE SOON
            //if( IsTouchingPauseButton() == false)
            //{

            //    rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);

            //}

            //else
            //{

            //}


        }


    }


    bool IsTouchingPauseButton()
    {
        if(Input.GetTouch(0).position.x > Screen.width - 100 && Input.GetTouch(0).position.y > Screen.height -100)
        {
            return true;
        }
        else
        {
            return false;
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

            col.transform.GetComponent<PlatformMovement>().movingSpeed += spawnBalloons.speedIncrement;
            

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
        col.offset = new Vector2(-0.015f, -0.055f);
        //col.size = new Vector2(0.13f, 0.13f);
        col.size = new Vector2(0.08f, 0.045f);
    }


    //method to switch Box Collider to Trigger
    public void ColliderToTrigger(BoxCollider2D col)
    {
        col.isTrigger = true;
        col.offset = new Vector2(0, -0.05f);
        col.size = new Vector2(1, 0.05f);
        Debug.Log("collider to trigger");

    }



    void IdleSpeed(PlatformMovement platformMov)
    {
        platformMov.movingSpeed += 0.001f;
    }


}
