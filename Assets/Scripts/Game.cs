using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static float gridWidth = 10;
    public static float gridHeight = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private static bool checkForXAxis(Vector3 position)
    {
        float position_x = position.x;
        return false;
    }

    private static bool checkForYAxis(Vector3 position)
    {
        return false;
    }

    public static bool IsInGrid(Vector3 position)
    {
        return false;
    }

}
