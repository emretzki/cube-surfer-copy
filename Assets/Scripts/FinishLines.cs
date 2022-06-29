using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLines : MonoBehaviour
{

    [SerializeField] private float multiplier;
    private PointCollector pointCollector;
    public float finishLineHeight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector")
        {
            pointCollector = other.GetComponent<PointCollector>();
            pointCollector.points = multiplier * pointCollector.points;
            pointCollector.pointsText.text = "Points: " + pointCollector.points;
            pointCollector.pointsTextGameOver.text = "Points: " + pointCollector.points;
        }
    }
}
