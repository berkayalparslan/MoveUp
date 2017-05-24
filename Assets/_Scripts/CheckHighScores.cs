using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CheckHighScores : MonoBehaviour
{

    public dbAccess dbScript;

    public GameObject addScoreWindow;

    public InputField inputField;
    public Button confirmButton;
    public Text warningText;

    public string usrName;

    public bool isNull;

    public int score;
	
	void Start ()
    {

        isNull = false;
        score = 0;

	}


    public void CheckScore(string value)
    {

        int score = System.Convert.ToInt32(value);

        //for (int i = 0; i < 5; i++)
        //{

        //    if(score > dbScript.score[i] )
        //    {

        //        this.score = score;
        //        addScoreWindow.SetActive(true);

        //        break;

        //    }
        //}

        if(score>dbScript.score[4])
        {
            this.score = score;
            addScoreWindow.SetActive(true);
        }
        

    }


    private void ShowInputImage()
    {
        addScoreWindow.SetActive(true);
    }


    public void ConfirmName()
    {
        IsInputFieldEmpty();

        if ( isNull == true )
        {
            warningText.gameObject.SetActive(true);
        }

        else
        {

            usrName = inputField.text;

            dbScript.AddRecord(usrName, score);
            addScoreWindow.SetActive(false);

            Debug.Log("button should be closed tbh");                       
            
        }
        
    }


    public void IsInputFieldEmpty()
    {

        if(inputField.text=="")
        {
            //confirmButton.interactable = false;
            isNull = true;
            Debug.Log("inputfield cant be empty !");
            
        }

        else
        {
            //confirmButton.interactable = true;
            isNull = false;
            Debug.Log("inputfield is ready to go");
            
            
        }
        //ConfirmName();

    }


}
