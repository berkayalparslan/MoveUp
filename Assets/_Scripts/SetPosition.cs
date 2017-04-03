using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{
    public Vector2 touchPos;

    private Image image;

	void Start ()
    {
        image = GetComponent<Image>();
        image.enabled = false;
	
	}
	
	
	void Update ()
    {

        if( Input.touchCount>0 )
        {

            touchPos = Input.GetTouch(0).position;

            image.rectTransform.position = touchPos;
            image.enabled = true;

        }

        else
        {
            image.enabled = false;
        }
	
	}


}
