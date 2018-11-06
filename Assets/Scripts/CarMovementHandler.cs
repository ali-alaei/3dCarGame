﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovementHandler : MonoBehaviour {
    private const float defaultSpeed = 5.0f;
    private float carSpeed = defaultSpeed; 
    private void CarSpeedController()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            carSpeed = carSpeed / 2;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            carSpeed = defaultSpeed;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            carSpeed = defaultSpeed * 2;
        }

        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CarSpeedController();
    }
}
