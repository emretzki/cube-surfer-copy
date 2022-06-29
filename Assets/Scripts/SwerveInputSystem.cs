using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{

    private float _lastFrameFingerPosition;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;
    [SerializeField] private GameObject MainCube;
    private float xRange = 4.5f;
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

            if (transform.position.x >= xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}
