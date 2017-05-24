﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameoverTextScript : MonoBehaviour
{

    public Text gameoverText;

    public GameObject gameOverMenu;

    public ScoreScript scoreScript;
    public CheckHighScores checkScoreScript;

    public bool isVisible;

	void Start ()
    {
        gameOverMenu.SetActive(false);
        gameObject.SetActive(false);
        isVisible = false;
	
	}


    void OnEnable()
    {

        gameoverText.text = "Your score\n \t  " + scoreScript.scoreText.text;
        //gameOverMenu.gameObject.SetActive(true);

        gameObject.SetActive(true);

        checkScoreScript.CheckScore(scoreScript.scoreText.text);

    }




}
