using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {
    private Light[] carLights;
    private void OnTriggerEnter(Collider car)
    {
        Debug.Log("entered");
        carLights = car.GetComponentsInChildren<Light>();
        foreach (Light light in carLights)
        {
            Debug.Log(carLights.Length);
            Debug.Log("in for");
            light.gameObject.SetActive(true);
        }
       
    }

    

    private void OnTriggerExit(Collider car)
    {
        Debug.Log("exit");
        foreach (Light light in carLights)
        {
            Debug.Log("in for");
            light.gameObject.SetActive(false);
        }
      
    }

    private void Update()
    {
     

    }
}
