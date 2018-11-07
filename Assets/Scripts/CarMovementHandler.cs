using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovementHandler : MonoBehaviour {
    private const float defaultSpeed = 8.0f;
    public AudioClip carHorn;
    private AudioSource horn;
    private Light[] carLights;
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

    private void TurnOnLightsAndHorn()


    {
        
        
        foreach (Light light in carLights)
        {
            if (Input.GetKey(KeyCode.P))
            {
                light.enabled = true;
                //carHorn.Play(0);
                horn.Play(0);
            }
            else
            {
                light.enabled = false;
                horn.Pause();
                //carHorn.Pause();

      
            }
                
        }

        
    }

    
    // Use this for initialization
	void Awake () {
        
        carLights = GetComponentsInChildren<Light>();
        horn = GetComponent<AudioSource>();
        //carHorn = GetComponentInChildren<AudioClip>();

    }
	
	// Update is called once per frame
	void Update () {

        CarSpeedController();
        CarMoveHandler();
        TurnOnLightsAndHorn();
    }
}
