using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timeClock : MonoBehaviour
{
    int hours = 12;
    int min = 0;
    float sec;
    public Text display;
    string time = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = $"{hours}:0{min} AM";
        sec += Time.deltaTime;
        if (sec >= 1.0f)
        {
            min++;
            sec = 0;
        }
        if (min >= 10)
        {
            time = $"{hours}:{min} AM";
        }
        if (min >= 60)
        {
            hours++;
            min = 0;
        }
        if (hours > 12)
        {
            hours = 1;
        }
        display.text = time;
        //Debug.Log(display.text);
    }
}
