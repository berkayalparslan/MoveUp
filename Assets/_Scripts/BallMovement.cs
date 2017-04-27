using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{

    public GameObject ballHolder;
    public SpawnBalconies spawnBalconies;
    public GameSettings gameSettings;

    private Rigidbody2D rb;


    public float movementDistance;
    public float invokeTimer=1.0f;
    
	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();

        ballHolder = null;

        movementDistance = 5.0f;

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

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && rb.velocity.normalized.y == 0 && gameSettings.gameOver==false || Input.GetKeyDown(KeyCode.W) )
        {
            rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);
            
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("touching the " + col.gameObject.name);

        if(col.gameObject.tag=="Platform" )
        {
            ballHolder = col.gameObject;
            ballHolder.transform.parent.GetComponent<Collider2D>().enabled = true;
            transform.SetParent(col.transform.parent);
        }

    }


    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Platform" )
        {
            
            col.transform.parent.parent.GetComponent<MoveBalcony>().CancelInvoke();
            

            //Vector3 pos = new Vector3(col.transform.parent.localPosition.x,
            //    col.transform.parent.localPosition.y + 0.1f,
            //    col.transform.parent.localPosition.z);

            //transform.position = pos;

        }

    }


    void OnTriggerExit2D(Collider2D col)
    {

        if( col.gameObject.tag == "Platform" )
        {
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>().Invoke("Move", invokeTimer);

            col.transform.parent.parent.GetComponent<MoveBalcony>().Invoke("MoveUp", invokeTimer);

            col.transform.parent.GetComponent<Collider2D>().enabled = false;
            transform.parent = null;

            col.transform.parent.GetComponent<PlatformMovement>().movingSpeed += spawnBalconies.incrementValue;

        }

    }


    public void Jump()
    {
        
        rb.AddForce(new Vector2(0, movementDistance), ForceMode2D.Impulse);
        Debug.Log("fucking jump u fucking cunt");

    }


}
