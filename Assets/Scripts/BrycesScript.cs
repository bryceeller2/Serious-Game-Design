using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BrycesScript : MonoBehaviour
{
    public float speed;
    private float amountToMove;
    public string value;

    SerialPort sp = new SerialPort("COM5", 9600); //Change this based on which USB port you're using
    
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        print("Bryce's Script is listening for Arduino Input");
    }

    // Update is called once per frame
    void Update()
    {
        amountToMove = speed * Time.deltaTime;

        if (sp.IsOpen)
        {
            try
            {
                value = sp.ReadExisting();
                value = value.Remove(3);
                MoveObject(value);
            }
            catch (System.Exception)
            {

            }
        }
    }

    void MoveObject(string Direction)
    {
        string output = "Input Sensed: " + Direction +" = ";
        if (Direction == "100")
        {
            // output += "Left";
            // transform.Translate(Vector3.left * amountToMove, Space.World);
            redActive.SetActive(false);
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (Direction == "010")
        {
            output += "Jump";
            //transform.Translate(Vector3.right * amountToMove, Space.World);
        }
        else if (Direction == "001")
        {
            // output += "Right";
            // transform.Translate(Vector3.right * amountToMove, Space.World);
            redActive.SetActive(true);
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            output += "No Action";
        }
        print(output);
    }
}
