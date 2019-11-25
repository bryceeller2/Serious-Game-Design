using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class EnableDisableYellow : MonoBehaviour
{
    public float speed;
    private float amountToMove;
    public string value;

    //SerialPort sp = new SerialPort("COM5", 9600); //Change this based on which USB port you're using
    //THIS SCRIPT GOES ON THE BLOCKS THEMSELVES

    // Start is called before the first frame update
    void Start()
    {
        //sp.Open();
        //sp.ReadTimeout = 1;
        //redActive = GameObject.Find("RedActive");
        print("Bryce's Script is listening for Arduino Input");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        //if (sp.IsOpen)
        //{
        //    try
        //    {
        //        value = sp.ReadExisting();
        //        value = value.Remove(3);
        //        MoveObject(value);

//                checkArduino();
  //          }
    //        catch (System.Exception)
      //      {

        //    }
        //}
    }

    void checkArduino()
    {

    }

    void MoveObject(string Direction)
    {
        //Activates an object based on the SECOND digit
        string output = "Input Sensed: " + Direction + " = ";
        if (Direction == "01" || Direction == "11")
        {
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (Direction == "00" || Direction == "10")
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            output += "No Action";
        }
        print(output);
    }
}
