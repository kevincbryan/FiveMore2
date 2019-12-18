using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDistraction : MonoBehaviour
{
    public bool isRandom = false;
    public bool isRepeating = false;
    public GameObject interactable;
    public float minTime;
    public float maxTime;
    private float time;
    private GameController gc;
    

    private float timeUntilFire = 0f;
    private bool runOnce = false;
    private bool reRun = false;
    public float reRunTime= 30f;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        time = maxTime;
        if (minTime < 0)
        {
            minTime = 0;
        }

        if (isRandom == true)
        {
            time = Random.Range(minTime, maxTime);
        }

        if(reRun == true)
        {
            time = reRunTime;
        }
    }

    private void Awake()
    {
        gc = FindObjectOfType<GameController>();
        time = maxTime;
        if (minTime < 0)
        {
            minTime = 0;
        }

        if (isRandom == true)
        {
            time = Random.Range(minTime, maxTime);
        }

        if (reRun == true)
        {
            time = reRunTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilFire += Time.deltaTime;
        
        //Debug.Log("Time is " + timeUntilFire);
        if (timeUntilFire >= time)
        {
            if (gc.distractions < gc.maxDistractions)
            {
                if (runOnce == false)
                {
                    runOnce = true;
                    interactable.SetActive(true);
                }
            }
            
        }
    }

    public void ResetObject ()
    {

        if (isRepeating == true)
        {
            timeUntilFire = 0;
            runOnce = false;
            reRun = true;
            time = Random.Range(minTime, maxTime);

        }
    }
}
