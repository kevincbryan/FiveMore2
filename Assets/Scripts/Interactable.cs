using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
    
{
    public bool isUsed = false;
    private GameController gameController;
    public TimedDistraction timer;
    public AudioSource annoyingSound;
    public Minigame mg;
    public static bool promptSolved = false;
    bool imPrompting = false;
   // public GameObject spriteToEnable;



    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        mg = gameObject.GetComponent<Minigame>();


    }

    // Update is called once per frame
    void Update()
    {
        if (imPrompting == true && promptSolved == true)
        {
            imPrompting = false;
            promptSolved = false;
            TurnOff();
        }
    }

    private void OnEnable()
    {
        gameController = FindObjectOfType<GameController>();       
        mg = gameObject.GetComponent<Minigame>();
        
        gameController.distractions++;

        //mg.Prompt();
        
        //annoyingSound.Play();
    }

    private void OnDisable()
    {
        //gameController.distractions--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsed == false)
        {
            if (collision.tag == "PlayerTouch")
            {
                isUsed = true;
                imPrompting = true;
                mg.Prompt();
                //TurnOff();
            }
        }
    }

    private void TurnOff()
    {
        gameController.distractions--;
        //annoyingSound.Stop();
        isUsed = false;
        //Debug.Log("This has been turned off");

        //spriteToEnable.SetActive(false);
        gameObject.SetActive(false);
        timer.ResetObject();

    }
}
