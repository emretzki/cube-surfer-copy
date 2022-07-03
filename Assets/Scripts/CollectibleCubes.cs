using UnityEngine;

public class CollectibleCubes : MonoBehaviour
{

    private bool isCollected;
    private int collectibleIndex;



    void Start()
    {

        isCollected = false;

    }

    void Update()
    {

        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -collectibleIndex, 0);
            }
        }
    }

    //Jumping from the obstacles.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            Collector.Instance.JumpFromObstacles(other);

        }
    }


    public bool GetIsCollected()
    {
        return isCollected;
    }

    public void Collect()
    {
        isCollected = true;
    }

    public void SetIndex(int collectibleIndex)
    {

        this.collectibleIndex = collectibleIndex;
    }
}
