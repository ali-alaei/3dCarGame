using System.Collections;
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
	private void CarMoveHandler()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * carSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * carSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * carSpeed * Time.deltaTime);
            carSpeed = 0.0f;
        }

    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CarSpeedController();
        CarMoveHandler();
    }
}
