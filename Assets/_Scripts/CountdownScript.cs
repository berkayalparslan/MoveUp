using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class CountdownScript : MonoBehaviour
{

    public Text countText;

    public Menu menu;

    public float timer;
    private bool triggered;

	void Awake ()
    {

        triggered = false;
        countText = GetComponent<Text>();
        timer = 3;
        gameObject.SetActive(false);
        
    }
	
	

	void Update ()
    {
        if(triggered==true)
        {
            StopCountdown();
            timer -= Time.deltaTime;
            countText.text = System.Convert.ToInt16(timer).ToString();
        }

	}


    public bool Triggered
    {
        set
        {
            triggered = true;
        }
        get
        {
            return triggered;
        }
    }


    public void StopCountdown()
    {

        if(timer<0.5f)
        {

            triggered = false;

            menu.StartTheGame(triggered);
            gameObject.SetActive(false);
            
        }

    }


}
