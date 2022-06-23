using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyPoint : MonoBehaviour
{

    [SerializeField] private float multiplier;
    private PointCollector pointCollector;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");

        if (other.gameObject.tag == "Collector")
        {
            pointCollector = other.GetComponent<PointCollector>();
            pointCollector.points = multiplier * pointCollector.points;
            pointCollector.pointsText.text = "Points: " + pointCollector.points;
        }

    }
}
