using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private GameObject MainCube;
    private int height;
    
    
    void Start()
    {
        MainCube = GameObject.Find("MainCube");

    }
    void Update()
    {

        MainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);

    }

    public void DecreaseHeight()
    {
        height--;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Cubes")
        {
            if (other.gameObject.GetComponent<CollectibleCubes>().GetIsCollected() == false)
            {
                height += 1;
                other.gameObject.GetComponent<CollectibleCubes>().Collect();
                other.gameObject.GetComponent<CollectibleCubes>().SetIndex(height);
                other.gameObject.transform.parent = MainCube.transform;
            }

        }
        if (other.gameObject.tag == "Finish")
        {
            ObstacleMethod(other);
            //MainCube.transform.position += new Vector3(0, 1, 0);
            Debug.Log("Entered to increase height");

        }

    }

        public void ObstacleMethod(Collider other)
    {

        DecreaseHeight();
        //transform.parent = null;
        //GetComponent<BoxCollider>().enabled = false;
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

}
