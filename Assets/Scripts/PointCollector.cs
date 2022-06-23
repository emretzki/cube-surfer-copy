using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    public float points;
    public Text pointsText;
    public Text pointsTextGameOver;
    
    

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Point"))
        {
            CalculatePoints(collision);
        }
    }
    private void CalculatePoints(Collider collision)
    {
        Destroy(collision.gameObject);
        points++;
        pointsText.text = "Points: " + points;
        pointsTextGameOver.text = "Points: " + points;

    }

}
