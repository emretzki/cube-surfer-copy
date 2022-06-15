using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{

    private float _lastFrameFingerPosition;
    private float _moveFactorX;

    public float MoveFactorX => _moveFactorX;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPosition = Input.mousePosition.x;
        }

        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPosition;
            _lastFrameFingerPosition = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}
