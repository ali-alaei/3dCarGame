using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour {

    public GameObject road;
    public GameObject car;
    public GameObject startPosition;    
    //public GameObject beginningOfRoad;
    private void OnTriggerEnter(Collider other)
    {
        //Vector3 beginningPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10.0f);
        //GameObject gameRoad = Instantiate(road);
        //gameRoad.transform.position = beginningPosition;
        //Instantiate()
        car.transform.position = startPosition.transform.position;

    }

}
