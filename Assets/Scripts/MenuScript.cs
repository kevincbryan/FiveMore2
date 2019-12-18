using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool isPressed = false;
    public Canvas startMenu;
    public GameObject startMennu;
    public Button playButton;
    public Slider volume;
    public Button exitButton;
    public GameObject exitText;
  
    
    


    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }


    // Start is called before the first frame update
    void Start()
    {
        startMenu = startMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        exitText = GameObject.Find("exitBox").GetComponent<GameObject>();

        exitText.SetActive(false);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLeve()
     {
        SceneManager.LoadScene("MainGame");
        Destroy(startMennu);
     }

    public void ExitPress()
    { 
        exitText.SetActive(true);
        
    }
    public void NoPress()
    {
        exitText.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
        
    }

}
