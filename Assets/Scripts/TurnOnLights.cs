using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour
{

    public GameObject RightLight;
    public GameObject LeftLight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            RightLight.SetActive(true);
            LeftLight.SetActive(true);
        }
    }



    private void OnTriggerExit(Collider car)
    {
        RightLight.SetActive(false);
        LeftLight.SetActive(false);
    }

}
