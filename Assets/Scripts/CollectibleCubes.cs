using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCubes : MonoBehaviour
{

    bool isCollected;
    int index;

    void Start()
    {

    }


    void Update()
    {
        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }

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

    public void SetIndex(int index)
    {
        this.index = index;
    }
}
