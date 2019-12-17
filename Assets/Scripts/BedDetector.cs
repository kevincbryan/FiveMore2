using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDetector : MonoBehaviour
{
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            if (gc != true)
            {
                gc = FindObjectOfType<GameController>();
            }

            gc.inBed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            gc.inBed = false;
        }
    }
}
