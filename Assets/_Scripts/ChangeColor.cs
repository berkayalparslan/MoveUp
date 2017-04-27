using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    public Renderer rend;

    public int colorNumber=0;

    void Awake()
    {
        colorNumber++;

    }

    void Start ()
    {

        rend = GetComponent<Renderer>();
        //colorNumber=Random.Range(0, 5);

        switch (colorNumber)
        {
            case 1:
                {
                    rend.material.color = Color.cyan;
                }break;
            case 2:
                {
                    rend.material.color = Color.green;
                }break;
            case 3:
                {
                    rend.material.color = Color.blue;
                }break;
            case 4:
                {
                    rend.material.color = Color.red;
                }break;
                
            default:
                break;
        }

    }
	

	void Update ()
    {
	
	}


}
