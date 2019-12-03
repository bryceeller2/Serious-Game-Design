using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class EnableDisable : MonoBehaviour
{
    public float speed;
    private float amountToMove;
    public string value;
    string output;
    public ListenerScript listener;
    //THIS SCRIPT GOES ON THE BLOCKS THEMSELVES

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        if (listener.rightEnabled == false)
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        //if (Input.GetKeyDown(KeyCode.X) || enabled == true)
        else if (listener.rightEnabled == true)
        {
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
