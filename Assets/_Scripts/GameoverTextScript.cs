using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameoverTextScript : MonoBehaviour
{

    public Text gameoverText;


    public FloorIncrementScript floorScript;


	void Start ()
    {

        gameoverText = GetComponent<Text>();
        gameObject.SetActive(false);
	
	}


    public void ShowText()
    {

        string score = floorScript.recentFloor.ToString();
        gameoverText.text = "Your score\n  "+ score;
        gameObject.SetActive(true);

    }


}
