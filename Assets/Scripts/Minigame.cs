using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public string[] inputs;
    public bool[] polarity;
    public string prompt = "";
    public PlayerController pc;
    public static bool isPrompted = false;
    public bool isMyPrompt = false;
    private int digitCheck = 0;
    public GameObject buttonPrompt;
    private Text buttonText;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Prompt();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrompted == true && isMyPrompt == true)
        {
            if (digitCheck < inputs.Length)
            {
                if(GetInput(digitCheck))
                {
                    digitCheck++;
                }
            }
            else
            {
                buttonPrompt = GameObject.FindGameObjectWithTag("ButtonPrompt");
                buttonText = buttonPrompt.GetComponent<Text>();
                buttonText.text = "";
                pc = FindObjectOfType<PlayerController>();
                Interactable.promptSolved = true;
                pc.playerStopped = false;
                isMyPrompt = false;
                isPrompted = false;
            }

           
        }
    }

    public void Prompt ()
    {

        if (isPrompted == false)
        {
            pc = FindObjectOfType<PlayerController>();
            pc.playerStopped = true;
            isPrompted = true;
            isMyPrompt = true;
            digitCheck = 0;
           
            inputs = ShuffleArray(inputs);
            polarity = ShuffleArray(polarity);
            //pc = FindObjectOfType<PlayerController>();


            Debug.Log("Prompt has been called");
            prompt = "";

            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == "Vertical")
                {
                    if (polarity[i] == true)
                    {
                        prompt += " Up ";
                    }
                    else
                    {
                        prompt += " Down ";
                    }
                }
                else
                {
                    if (polarity[i] == true)
                    {
                        prompt += " Right ";
                    }
                    else
                    {
                        prompt += " Left ";
                    }
                }
            }

            buttonPrompt = GameObject.FindGameObjectWithTag("ButtonPrompt");
            buttonText = buttonPrompt.GetComponent<Text>();
            buttonText.text = prompt;
            
            Debug.Log(prompt);
            //bool correct = GetInput(0);


        }
        
    }


    bool GetInput(int i)
    {
        

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if ((inputs[i] == "Horizontal") && polarity[i] == true && Input.GetAxis("Horizontal") > 0)
            {
                //pc.playerStopped = false;
                return (true);
            }
            else if ((inputs[i] == "Horizontal") && polarity[i] == false && Input.GetAxis("Horizontal") < 0)
            {
                //pc.playerStopped = false;
                return (true);
            }
            else if ((inputs[i] == "Vertical") && polarity[i] == true && Input.GetAxis("Vertical") > 0)
            {
                //pc.playerStopped = false;
                return (true);
            }
            else if ((inputs[i] == "Vertical") && polarity[i] == false && Input.GetAxis("Vertical") < 0)
            {
                //pc.playerStopped = false;
                return (true);
            }
            else
            {
               // pc.playerStopped = false;
                return (false);
            }


        }
        else
        {
            return (false);
        }





    }

    string[] ShuffleArray(string[] arraySort)
    {
        int n = arraySort.Length;
        string holder;
        // Sorts arrays given to it        
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            holder = arraySort[k];
            arraySort[k] = arraySort[n];
            arraySort[n] = holder;

        }

        return (arraySort);
    }

    bool[] ShuffleArray(bool[] arraySort)
    {
        int n = arraySort.Length;
        bool holder;
        // Sorts arrays given to it        
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            holder = arraySort[k];
            arraySort[k] = arraySort[n];
            arraySort[n] = holder;

        }

        return (arraySort);
    }
}
