using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainCubeCollision : MonoBehaviour 
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public SwerveMovement swerveMovement;
    public GameObject finishedPanel;
    


   
    private void OnTriggerEnter(Collider other)
    {
        ResetSpeed(other);
    }

    public void ResetSpeed(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
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

        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("test");
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
    }

    private void Finish(Collider other)
    {
        if(other.gameObject.tag == "Trophy")
        {
            finishedPanel.SetActive(true);
            player.transform.position = respawnPoint.transform.position;
        }
        else
        {
            swerveMovement.SwerveSettings();
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
