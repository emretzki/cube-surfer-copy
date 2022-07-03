using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    public double points;
    public Text pointsText;
    public Text pointsTextGameOver;
    public Text pointsTextFinished;

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
        points = points + 1;
        pointsText.text = "Points: " + points;
        pointsTextGameOver.text = "Points: " + points;

    }

}
