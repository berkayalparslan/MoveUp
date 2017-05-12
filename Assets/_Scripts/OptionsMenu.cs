using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OptionsMenu : MonoBehaviour
{

    public Button optionsButton;

    public Image optionsMenu;

    

    void Start ()
    {
        //optionsMenu = GetComponent<Image>();
        optionsMenu.gameObject.SetActive(false);
	}


    void Update ()
    {
		
	}


    public void ToggleOptionsMenu()
    {

        if(optionsMenu.IsActive()==false)
        {
            optionsMenu.gameObject.SetActive(true);
        }

        else
        {
            optionsMenu.gameObject.SetActive(false);
        }

    }


}
