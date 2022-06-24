using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    public float points;
    public Text pointsText;
    public Text pointsTextGameOver;
    
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Point"))
        {
            PointCalculator(collision);
        }
    }


    //Calculating and printing points to the UI here
    private void PointCalculator(Collider collision)
    {
        Destroy(collision.gameObject);
        points++;
        pointsText.text = "Points: " + points;
        pointsTextGameOver.text = "Points: " + points;

    }

}
