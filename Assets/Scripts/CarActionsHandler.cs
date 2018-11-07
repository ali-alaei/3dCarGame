using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarActionsHandler : MonoBehaviour {

    private const float defaultSpeed = 8.0f;
    public AudioClip CarHorn;
    public GameObject RightLight;
    public GameObject LeftLight;
    public List<GameObject> obstacles;
    private AudioSource horn;
    private float carSpeed;

    private void SaveInPlayerPrefs(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    private void GetSpeedFromPlayerPrefs(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            carSpeed = PlayerPrefs.GetFloat(key);
            print("carSpeed" + carSpeed);
        }
        else
        {
            carSpeed = defaultSpeed;
        }
        
    }
    private void CarSpeedController()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            carSpeed = carSpeed / 2;
            SaveInPlayerPrefs("CarSpeed", carSpeed);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            carSpeed = defaultSpeed;
            SaveInPlayerPrefs("CarSpeed", carSpeed);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            carSpeed = defaultSpeed * 2;
            SaveInPlayerPrefs("CarSpeed", carSpeed);
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

    private void ObstacleMaker()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            int obstaclType = Random.Range(0, 2);
            print(obstaclType);
            GameObject obstacle = Instantiate(obstacles[obstaclType]);
            obstacle.transform.position = new Vector3(transform.position.x, 10*transform.position.y, transform.position.z);
        }
    }

    
    // Use this for initialization
	void Awake () {
	    horn = GetComponent<AudioSource>();
	    GetSpeedFromPlayerPrefs("CarSpeed");
	    
	}
	
	// Update is called once per frame
	void Update () {
        CarSpeedController();
        CarMoveHandler();
        TurnOnLightsAndHorn();
	    ObstacleMaker();
    }
}
