using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ListenerScript : MonoBehaviour
{
    public float speed;
    private float amountToMove;
    public string value;

    public bool leftEnabled;
    public bool rightEnabled;
    public bool midEnabled;


    SerialPort sp = new SerialPort("COM5", 9600); //Change this based on which USB port you're using
    //THIS SCRIPT GOES ON THE BLOCKS THEMSELVES

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        leftEnabled = false;
        midEnabled = false;
        rightEnabled = false;
        print("Listener Script is listening for Arduino Input");
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                value = sp.ReadExisting();
                value = value.Remove(3);
                if (value.Length == 3 && char.IsDigit(value, 0) && char.IsDigit(value, 1) && char.IsDigit(value, 2))
                    MoveObject(value);
            }
            catch (System.Exception)
            {

            }
        }
    }
    
    void MoveObject(string Direction)
    {
        //Activates an object based on the FIRST digit
        string output = "Input Sensed: " + Direction +" = ";
        if (Direction == "100" || Direction == "101")
        {
            leftEnabled = true;
        }
        else if (Direction == "000" || Direction == "001")
        {
            leftEnabled = false;
        }
        if (Direction == "001" || Direction == "101")
        {
            rightEnabled = true;
        }
        else if (Direction == "000" || Direction == "100")
        {
            rightEnabled = false;
        }
        if (Direction == "010" || Direction == "110" || Direction == "011" || Direction == "111")
        {
            midEnabled = true;
        }
        else if (Direction == "000" || Direction == "100" || Direction == "001" || Direction == "101")
        {
            midEnabled = false;
        }
    }
}
