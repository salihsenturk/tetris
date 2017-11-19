﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrisform : MonoBehaviour {

    float fall = 0;
    float fallSpeed = 1;
    bool stopGoingDown = false;

     // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckUserInput();
	}

    void CheckUserInput()
    {
        
        if (Input.inputString != null)
        {
            //Debug.Log("The key entered is " + Input.inputString.ToString());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1,0,0);
            
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0);
        }else if (!stopGoingDown && Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-1,0);
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }else if (!stopGoingDown && GoDown())
        {
            transform.position += new Vector3(0, -1,0);
        }
        
    }

    bool GoDown()
    {
        float myTime = Time.time;
        bool isGoDown = myTime - fall > fallSpeed;
        fall = isGoDown ? myTime:fall;
        return isGoDown;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(!collision.gameObject.name.Equals("Left Wall") && !collision.gameObject.name.Equals("Right Wall") && collision.gameObject.transform.position.y < gameObject.transform.position.y) {
            stopGoingDown = true;
        }
    }
}
