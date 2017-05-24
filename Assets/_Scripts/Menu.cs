using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{

    public Button startButton;
    public Button pauseButton;
    public Button optionsButton;
    public Button highScoresButton;
    public Button creditsButton;

    public Image mainMenu;
    public Image pauseMenu;

    public Text scoreText;

    private GameStatus gameStatus;
    public CountdownScript countdownScript;


    void Start ()
    {

        gameStatus = GetComponent<GameStatus>();    

    }


    void Update ()
    {
        //Debug.Log(Time.timeScale);
	
	}

    public void StartTheGame()
    {
        // UI items to disappear
        mainMenu.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        highScoresButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

        Time.timeScale = 1.0f;
        //Ingame UI items to appear
        countdownScript.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        countdownScript.Triggered = true;
        

    }


    public void StartTheGame(bool triggered)
    {

        if(triggered==false)
        {

            gameStatus._Start();

        }

    }
    

    public void PauseOrContinue()
    {

        if(gameStatus.gamePaused == false && gameStatus.gameOver==false )
        {

            gameStatus.Pause();
            pauseMenu.gameObject.SetActive(true);

        }

        else
        {

            pauseMenu.gameObject.SetActive(false);
            gameStatus.Continue();

        }

    }


    public void RestartTheGame()
    {
        pauseMenu.gameObject.SetActive(false);
        gameStatus.Restart();
    }


    public void ToggleMenu(GameObject obj)
    {

        if (obj.activeSelf == false)
        {
            obj.SetActive(true);
        }

        else
        {
            obj.SetActive(false);
        }

    }


}
