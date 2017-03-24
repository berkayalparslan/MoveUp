using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreScript : MonoBehaviour
{
    public Text floor;
    public FloorScript floorNo;

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
