using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BlinkingScript : MonoBehaviour
{

    public GameStatus gameStatus;
    public GameoverTextScript gameoverScript;
    public GameObject gameOverMenu;

    public Image image;

    public float alphaValue;

    public bool blinkTriggered;
    public bool increase = false;
    public bool decrease = false;

    public float counter=0;


	void Start ()
    {
        image = GetComponent<Image>();

       

        alphaValue = image.color.a;

        blinkTriggered = false;

    }

	
	void Update ()
    {

        BlinkImage();
        //you were doing something here but you should remember... go out for a walk and rest.
        //finally you found out it. gratz.

	}


    private void BlinkImage()
    {

        image.color = new Color(255, 255, 255, alphaValue);

        if (blinkTriggered == true)
        {

            if (increase == true && decrease == false)
            {

                IncreaseAlpha();

            }

            if (decrease == true && increase == false)
            {

                DecreaseAlpha();

            }

            if (counter < 3)
            {

                if (alphaValue > 0.8f)
                {

                    decrease = true;
                    increase = false;

                }


                if (alphaValue < 0.2f)
                {

                    increase = true;
                    decrease = false;

                }

            }

            else
            {

                StopBlinking();
                gameOverMenu.gameObject.SetActive(true);
                
                
                //gameSettings.Pause();
                

            }

        }

    }


    public void StartBlinking()
    {
        
        blinkTriggered = true;
        
    }


    public void StopBlinking()
    {
        
        blinkTriggered = false;
        
    }


    void DecreaseAlpha()
    {

        alphaValue-=Time.deltaTime;
        //Debug.Log(alphaValue);
        
    }


    void IncreaseAlpha()
    {
        alphaValue+=Time.deltaTime;
        //Debug.Log(alphaValue);
        counter+=Time.deltaTime;

    }


}
