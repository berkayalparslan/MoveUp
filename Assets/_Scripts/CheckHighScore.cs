using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CheckHighScore: MonoBehaviour
{
    //XML
    public ScriptXML xmlScript;

    public int score;
	

	void Start ()
    {
        score = 0;

	}


    public void CheckScore(string value)
    {

        int score = System.Convert.ToInt32(value);

        //XML
        if (score > xmlScript.score)
        {
            xmlScript.AddRecord(score);
        }

    }

}
