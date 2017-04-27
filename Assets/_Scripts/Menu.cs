using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{

    public Button startButton;
    public Button pauseButton;

    public Image mainMenu;
    public Image pauseMenu;

    private GameSettings settings;


    void Start ()
    {

        settings = GetComponent<GameSettings>();
        Time.timeScale = 0;

    }


    void Update ()
    {
	
	}

    public void StartTheGame()
    {

        mainMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        settings.Continue();

    }
    

    public void PauseOrContinue()
    {

        if(settings.gamePaused == false)
        {

            settings.Pause();
            pauseMenu.gameObject.SetActive(true);

        }

        else
        {

            pauseMenu.gameObject.SetActive(false);
            settings.Continue();

        }

    }


    public void RestartTheGame()
    {
        pauseMenu.gameObject.SetActive(false);
        settings.Restart();
    }


}
