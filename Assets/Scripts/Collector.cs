using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private GameObject MainCube;
    public int height;
    private bool finishActivated;
    private FinishLines finishLines;
    private float finishLineSum;
    private float finishLineCollector;
    public List<CollectibleCubes> collectibleCubesList = new List<CollectibleCubes>();
    TriggerEvents triggerEvents;
    

    void Start()
    {
        MainCube = GameObject.Find("MainCube");
        triggerEvents = this.gameObject.GetComponent<TriggerEvents>();
    }

    //Increasing height of the main cube, collecting cube stays bottom.
    void Update()
    {

        MainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);


        if (finishActivated)
        {
            Debug.Log("Entered to increase height");
            MainCube.transform.position = new Vector3(transform.position.x, height + finishLineSum, transform.position.z);
            this.transform.localPosition = new Vector3(0, -height - finishLineCollector, 0);
        }

    }


    //Adding cubes and setting the range of the added cubes.
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Cubes")
        {
            var collectibleCube = other.gameObject.GetComponent<CollectibleCubes>();

            if (collectibleCube.GetIsCollected() == false)
            {
                collectibleCubesList.Add(collectibleCube);
                height += 1;
                collectibleCube.Collect();
                collectibleCube.SetIndex(height);
                other.gameObject.transform.parent = MainCube.transform;
            }

        }

        if (other.gameObject.tag == "Finish")
        {
           
            if (collectibleCubesList.Count == 0)
            {
                
            }
            else
            {
                JumpFromObstacles(other);
                finishActivated = true;
                finishLines = other.GetComponent<FinishLines>();
                finishLineSum = finishLines.finishLineHeight;
            }
        }

        
    }

    public void JumpFromObstacles(Collider other)
    {

        if (collectibleCubesList.Count == 0)
        {
            
        }
        else
        {
            collectibleCubesList[collectibleCubesList.Count - 1].gameObject.transform.parent = null;
            collectibleCubesList.RemoveAt(collectibleCubesList.Count - 1);
            height--;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;


        }

    }
}

