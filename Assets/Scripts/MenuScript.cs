using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool isPressed = false;
    public Canvas startMenu;
    public Button playButton;
    public Slider volume;
    public Button exitButton;
    public Text exitText;


    // Start is called before the first frame update
    void Start()
    {
        startMenu = startMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();


        exitButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* public void LoadLeve()
     {
         Application.LoadLevel("");
     }*/

    public void ExitPress()
    {
        exitButton.enabled = true;
        playButton.enabled = false;

    }
    public void NoPress()
    {
        exitButton.enabled = false;
        playButton.enabled = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
