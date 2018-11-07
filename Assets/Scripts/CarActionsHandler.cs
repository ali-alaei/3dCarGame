using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarActionsHandler : MonoBehaviour {

    private const float defaultSpeed = 8.0f;
    public AudioClip CarHorn;
    public GameObject RightLight;
    public GameObject LeftLight;
    private AudioSource horn;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            RightLight.SetActive(true);
            LeftLight.SetActive(true);
            horn.Play(0);
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            RightLight.SetActive(false);
            LeftLight.SetActive(false);
            horn.Pause();
            
        }
        
       
    }

    
    // Use this for initialization
	void Awake () {
        
        
        horn = GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update () {

        CarSpeedController();
        CarMoveHandler();
        TurnOnLightsAndHorn();
    }
}
