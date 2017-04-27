using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FloorTextScript : MonoBehaviour
{
    public Text floor;
    public FloorIncrementScript floorNo;

    public int score;


	void Start ()
    {
        floor = GetComponent<Text>();
	
	}
	

	void Update ()
    {

        floor.text = "Floor " + score.ToString();
	
	}


}
