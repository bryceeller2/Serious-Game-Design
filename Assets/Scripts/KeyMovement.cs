using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class KeyMovement : MonoBehaviour
{
    public int speed;
    int timer = 0;
    public ListenerScript listener;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        Vector3 position = this.transform.position;

        if (timer % speed == 0 && listener.midEnabled==false)
        {
            position.x += 1;
            this.transform.position = position;
            timer = 0;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position = this.transform.position;
            position.x-=1;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position = this.transform.position;
            position.x+=1;
            this.transform.position = position;
        }

        if (this.transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
