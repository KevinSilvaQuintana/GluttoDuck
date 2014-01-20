using UnityEngine;
using System.Collections;

public class PrefabLoadingScript : MonoBehaviour {

    // Foods
    public GameObject candyA;
    public GameObject candyB;
    public GameObject candyC;
    public GameObject donut;
    public GameObject lollipop;

    // Interactables
    public GameObject rainbow;
    public GameObject cloud;

    public bool sequential;

    private float bounds = 2.5f;

    private float minDelay = 0.5f;
    private float maxDelay = 1.0f;
    private float nextSpawn;
    private float currentTime;

    //private SpeedRegulator speedRegulator;

    private int sequentialCount = 5;
    private float sequentialDelay = 0.1f;
    private float sequentialTimer = 0f;

    bool done = false;
    //bool test = true;
	void Start ()
    {
        nextSpawn = Random.Range (minDelay,maxDelay);
        currentTime = 0f;
        //speedRegulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();

	}
	
	
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (sequential)
        {

            if(currentTime > nextSpawn)
            {
                done = false;
            }

            if(!done)
            {
                sequentialTimer += Time.deltaTime;
                if(sequentialTimer > sequentialDelay)
                {
                    sequentialTimer = 0f;
                    SpawnRandomFood ();
                    sequentialCount--;
                    if(sequentialCount == 0)
                    {
                        done = true;
                        nextSpawn = Random.Range (minDelay,maxDelay);
                        sequentialCount = 5;
                        sequentialTimer = 0f;
                        transform.position = new Vector3(Random.Range (-bounds, bounds), transform.position.y, transform.position.z);
                        nextSpawn = Random.Range (minDelay*3,maxDelay*4);
                        currentTime = 0f;
                    }
                }
            }
        }
        else
        {
            transform.position = new Vector3(Random.Range (-bounds, bounds), transform.position.y, transform.position.z);
            if(currentTime > nextSpawn)
            {
                SpawnRandomFood();

                currentTime = 0f;
                nextSpawn = Random.Range (minDelay,maxDelay);
                GameObject o;

                // Random spawn of boost or cloud (Chance)
                int randomCloudOrRainbow = Random.Range (0,10);
                transform.position = new Vector3(Random.Range (-bounds, bounds), transform.position.y, transform.position.z);
                if(randomCloudOrRainbow < 1)
                {
                    o = Instantiate(rainbow, transform.position, Quaternion.identity) as GameObject;
                    o.GetComponent<DescendingScript>().setMoveSpeed(Random.Range (0.4f,0.7f));
                }
                else if(randomCloudOrRainbow < 5)
                {
                    o = Instantiate(cloud, transform.position, Quaternion.identity) as GameObject;
                    o.GetComponent<DescendingScript>().setMoveSpeed(Random.Range (0.4f,0.7f));
                }
            }



        }



//        if(test)
//        {
//            test = false;
//
//            GameObject prefab;
//            //Vector3 pos = new Vector3(0,0,0);
//
//            //Instantiate(prefabA,transform.position, new Vector3(0,0,0));
//            Instantiate (candyA, transform.position, Quaternion.identity);
////            GameObject.Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/CandyA.prefab", typeof(GameObject)) as GameObject);
//        }

	}


    void SpawnRandomFood()
    {
        int num = Random.Range (0,5);
        switch (num)
        {
        case 0:
            Instantiate(candyA, transform.position, Quaternion.identity);
            break;
        case 1:
            Instantiate(candyB, transform.position, Quaternion.identity);
            break;
        case 2:
            Instantiate(candyC, transform.position, Quaternion.identity);
            break;
        case 3:
            Instantiate(donut, transform.position, Quaternion.identity);
            break;
        case 4:
            Instantiate(lollipop, transform.position, Quaternion.identity);
            break;

        default:
            break;
        }

    }
}
