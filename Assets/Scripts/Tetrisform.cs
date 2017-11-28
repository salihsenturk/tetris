using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrisform : MonoBehaviour {

    float fall = 0;
    float fallSpeed = 1;
    bool stopMoving = false;
    bool leftOff = false, rightOff = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckUserInput();
        
	}

    void CheckUserInput()
    {
        //if(!stopMoving) {
            if (Input.inputString != null) {
                //Debug.Log("The key entered is " + Input.inputString.ToString());
            }

            if (!rightOff && Input.GetKeyDown(KeyCode.RightArrow)) {
                transform.position += new Vector3(.5f, 0, 0);
                leftOff = false;
            } else if (!leftOff && Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.position += new Vector3(-.5f, 0, 0);
                rightOff = false;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                transform.position += new Vector3(0, -1, 0);
            } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                transform.Rotate(new Vector3(0, 0, 90));
            } else if (GoDown()) {
                transform.position += new Vector3(0, -1, 0);
            }
        //}
    }

    bool GoDown()
    {
        float myTime = Time.time;
        bool isGoDown = myTime - fall > fallSpeed;
        fall = isGoDown ? myTime:fall;
        return isGoDown;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name + " collision");
        Debug.Log(collision.contacts.Length);

        if (collision.gameObject.name.Equals("Left Wall")) {
            leftOff = true;
        } else if (collision.gameObject.name.Equals("Right Wall")) {
            rightOff = true;
        } else if (collision.gameObject.name.Equals("Floor") || collision.gameObject.transform.position.y < gameObject.transform.position.y) {
            stopMoving = true;
            this.enabled = false;
        }

        for (int i = 0; i < collision.contacts.Length; i++) {
            Debug.Log(collision.contacts[0].normal);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        Debug.Log(trigger.gameObject.name + " trigger");
        if (trigger.gameObject.name == "Floor") {
            stopMoving = true;
        }

        if (trigger.gameObject.name.Equals("Left Wall")) {
            leftOff = true;
        }
        if (trigger.gameObject.name.Equals("Right Wall")) {
            rightOff = true;
        }
        if (!trigger.gameObject.name.Equals("Left Wall") && !trigger.gameObject.name.Equals("Right Wall") && trigger.gameObject.transform.position.y < gameObject.transform.position.y) {
            stopMoving = true;
        }
    }

    public bool IsMoving() {
        return !stopMoving;
    }
}
