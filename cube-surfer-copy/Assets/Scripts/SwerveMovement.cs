using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;

    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float forwardSpeed;



    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        transform.Translate(swerveAmount, 0, forwardSpeed * Time.deltaTime);
        
    }

}
