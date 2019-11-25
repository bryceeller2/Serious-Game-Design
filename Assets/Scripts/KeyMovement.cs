using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{

    int speed = 5;
    int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        Vector3 position = this.transform.position;

        if (timer % speed == 0)
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

    }
}
