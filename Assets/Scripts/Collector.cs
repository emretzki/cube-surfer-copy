using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int height;
    private bool finishActivated;
    private FinishLines finishLines;
    private float finishLineCollector;
    private float finishLineSum;
    public List<CollectibleCubes> collectibleCubesList = new List<CollectibleCubes>();
    public TriggerToFinish triggerEvents;
    [SerializeField] private GameObject Player;



    private static Collector _instance;

    public static Collector Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {


    }

    //Increasing height of the main cube, collecting cube stays bottom.
    void Update()
    {

        Player.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);


        if (finishActivated)
        {
            Player.transform.position = new Vector3(transform.position.x, height + finishLineSum, transform.position.z);
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
                other.gameObject.transform.parent = Player.transform;
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

        if (other.gameObject.tag == "Trophy")
        {
            triggerEvents.RestartMethod(other);

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

