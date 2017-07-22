using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameoverTextScript : MonoBehaviour
{

    public Text gameoverText;

    public GameObject gameOverMenu;

    public ScoreScript scoreScript;
    public CheckHighScore checkScoreScript;

    public bool isVisible;

	private void Start ()
    {
        gameOverMenu.SetActive(false);
        gameObject.SetActive(false);
        isVisible = false;
	
	}


    private void OnEnable()
    {

        gameoverText.text = "Your score\n \t  " + scoreScript.scoreText.text;

        gameObject.SetActive(true);

        //XML
        checkScoreScript.CheckScore(scoreScript.scoreText.text);

    }




}
