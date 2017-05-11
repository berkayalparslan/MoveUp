using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;

    public int score;

    void Start ()
    {
        
        scoreText = GetComponent<Text>();
        score = 0;
        scoreText.text = score.ToString();
        gameObject.SetActive(false);

    }


    void Update ()
    {
	
	}


    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


}
