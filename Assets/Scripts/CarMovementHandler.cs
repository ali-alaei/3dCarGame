using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovementHandler : MonoBehaviour {
    private const float defaultSpeed = 8.0f;
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 2*carSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, 100 * Time.deltaTime, Space.World);
            transform.Translate(Vector3.left * carSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 100 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * 2*carSpeed * Time.deltaTime);
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
