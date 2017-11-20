using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShapes : MonoBehaviour {

    public List<GameObject> shapes = new List<GameObject>();
    GameObject currentShape;
    Tetrisform currentScript;

    // Use this for initialization
    void Start () {
        GetRandomShape();
    }
	
	// Update is called once per frame
	void Update () {
        if(!currentScript.IsMoving()) {
            GetRandomShape();
        }
    }

    void GetRandomShape() {
        int randomIndex = UnityEngine.Random.Range(0, 7);
        var position = new Vector3(6f, 14.5f, 0f);
        currentShape = Instantiate(shapes[randomIndex], position, Quaternion.identity);
        currentScript = currentShape.GetComponent<Tetrisform>();
    }
}
