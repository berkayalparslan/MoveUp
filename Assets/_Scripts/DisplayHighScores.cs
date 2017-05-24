using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DisplayHighScores : MonoBehaviour
{

    public dbAccess db;

    public string list;
    public int numberOfRecords;

    public Text scoreText;


    void Start ()
    {
        numberOfRecords = 5;
	}


    void OnEnable()
    {
        ShowRecords();
    }


    void OnDisable()
    {
        list = "";
    }


    public void ShowRecords()
    {
        db.GetRecords();
        for (int i = 0; i < db.record.Length; i++)
        {
            
            list += db.record[i] + "\n";
        }
        
        scoreText.text = list;
    }


}
