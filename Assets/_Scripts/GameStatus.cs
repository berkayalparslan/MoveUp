using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{

    public GameObject ball;
    
    public BlinkingScript blinkingScript;
    public SpawnFloors spawnFloors;
    public PlatformMovement platformMovement;
    public GameoverTextScript gameoverTextScript;

    public bool gameStarted;
    public bool gameOver;
    public bool gamePaused;


    void Awake ()
    {
        //ball.transform.SetParent(spawnBalconies.balconies[0].transform.GetChild(0).transform);
        Time.timeScale = 0.0f;
        
        gamePaused = true;
        gameOver = false;

        Debug.Log(" streaming assets path is : "+Application.streamingAssetsPath);
        Debug.Log(" persistent data path is : " + Application.persistentDataPath);
        Debug.Log(" application path is : " + Application.dataPath);

    }


    private void Start()
    {
        gameStarted = false;
    }


    public bool GameStarted
    {
        get
        {
            return gameStarted;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
        
    }


    public void Pause()
    {
        //Time.timeScale = 0.0f;
        gamePaused = true;
    }


    public void _Start()
    {

        gameStarted = true;
        gamePaused = false;
        //Time.timeScale = 1.0f;

    }


    public void Continue()
    {
        gamePaused = false;
        //Time.timeScale = 1.0f;
        
    }


    public void GameOver(bool isOver)
    {

        if(isOver==true)
        {

            gameOver = true;
            blinkingScript.StartBlinking();
            //gameoverTextScript.ShowMenu();
            
        }

        else
        {
            gameOver = false;
        }

    }

    


}
