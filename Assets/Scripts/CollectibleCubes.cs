using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCubes : MonoBehaviour
{

    private bool isCollected;
    private int index;
    public Collector collector;
       
      
    void Start()
    {
        
        isCollected = false;     
    }

    void Update()
    {

        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            collector.ObstacleMethod(other);
        }

        if (other.gameObject.tag == "Finish")
        {

            transform.parent = null;
            Debug.Log("Collectible cube run");

        }
    }


    public bool GetIsCollected()
    {
        return isCollected;
    }

    public void Collect()
    {
        isCollected = true;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }
}
