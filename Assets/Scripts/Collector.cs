using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject MainCube;
    int height;
    void Start()
    {
        MainCube = GameObject.Find("MainCube");

    }
    void Update()
    {
        
        MainCube.transform.position = new Vector3(transform.position.x, height + 1 , transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Collector")
        {
            height += 1;
            other.gameObject.GetComponent<CollectibleCubes>().Collect();
            other.gameObject.GetComponent<CollectibleCubes>().SetIndex(height);
            other.gameObject.transform.parent = MainCube.transform;
        }     
       
    }
}
