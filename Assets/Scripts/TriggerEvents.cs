using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public SwerveMovement swerveMovement;
    public GameObject finishedPanel;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            RestartMethod(other);
        }

        if (other.gameObject.tag == "Finish")
        {
            RestartMethod(other);
        }

    }

    public void RestartMethod(Collider other)
    {

        gameOver = true;
        swerveMovement.forwardSpeed = 0f;
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            player.transform.position = respawnPoint.transform.position;
        }
        else
        {
            swerveMovement.SwerveSettings();
        }


        if (other.gameObject.tag == "Finish")
        {

            gameOver = true;
            swerveMovement.forwardSpeed = 0f;
            if (gameOver)
            {
                gameOverPanel.SetActive(true);
                player.transform.position = respawnPoint.transform.position;
            }
            else
            {
                swerveMovement.SwerveSettings();
            }
        }


        if (other.gameObject.tag == "Trophy")
        {

            gameOver = true;
            swerveMovement.forwardSpeed = 0f;
            if (gameOver)
            {
                gameOverPanel.SetActive(false);
                finishedPanel.SetActive(true);
                player.transform.position = respawnPoint.transform.position;
            }
        }
    }

}
