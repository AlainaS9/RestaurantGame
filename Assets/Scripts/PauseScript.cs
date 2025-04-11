using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public Button pauseButton;
    public GameObject resumeButton;
    public GameObject exitButton;

    public GameObject customerSelector;
    public GameObject foodSelector;

    public bool isPaused;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            pauseButton.onClick.AddListener(Pause);
        }
        else if (isPaused) 
        {
          //  pauseButton.onClick.AddListener(Resume);
        }
        
    }

    void Pause()
    {
        audioSource.Play();
        Time.timeScale = 0;
        Debug.Log("Paused!");
        isPaused = true;
        resumeButton.SetActive(true);
        exitButton.SetActive(true);

        customerSelector.GetComponent<CustomerSelectScript>().isPaused = true;
        foodSelector.GetComponent<FoodSelectScript>().isPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1;
        Debug.Log("Unpaused!");
        isPaused = false;
    }
   
}
