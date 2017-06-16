using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CheckHighScores : MonoBehaviour
{
    //DB
    public dbAccess dbScript;

    public int score;
	
	void Start ()
    {
        score = 0;

	}


    public void CheckScore(string value)
    {

        int score = System.Convert.ToInt32(value);

        //DB
        if (score > dbScript.score)
        {
            dbScript.AddRecord(score);
        }

    }

    


}
