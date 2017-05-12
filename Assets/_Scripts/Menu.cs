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


    void Start ()
    {

        gameStatus = GetComponent<GameStatus>();
        Time.timeScale = 0;

    }


    void Update ()
    {
	
	}

    public void StartTheGame()
    {

        mainMenu.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        highScoresButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        gameStatus.Continue();

    }
    

    public void PauseOrContinue()
    {

        if(gameStatus.gamePaused == false)
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





}
