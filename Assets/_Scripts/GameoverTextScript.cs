using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameoverTextScript : MonoBehaviour
{

    public Text gameoverText;

    public GameObject gameOverMenu;

    public ScoreScript scoreScript;

	void Start ()
    {
        gameOverMenu.SetActive(false);
        gameoverText = GetComponent<Text>();
        gameObject.SetActive(false);
	
	}


    public void ShowMenu()
    {
        gameoverText.text = "Your score\n  "+ scoreScript.scoreText.text;
        gameOverMenu.gameObject.SetActive(true);
        gameObject.SetActive(true);

    }




}
