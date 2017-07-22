using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;

    public int score;
    public int highScore;


    void Start ()
    {
        
        scoreText = GetComponent<Text>();

        score = 0;
        scoreText.text = score.ToString();

        gameObject.SetActive(false);

        highScore = System.Int32.Parse(highScoreText.text);

    }


    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score>highScore)
        {

            highScore++;
            highScoreText.text = highScore.ToString();

        }

    }


}
