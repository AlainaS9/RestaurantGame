using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeScript : MonoBehaviour
{
    public Button resumeButton;
    public GameObject pauseButton;
    public GameObject exitButton;

    public GameObject customerSelector;
    public GameObject foodSelector;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Resume()
    {
        audioSource.Play();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        exitButton.SetActive(false);

        customerSelector.GetComponent<CustomerSelectScript>().isPaused = false;
        foodSelector.GetComponent<FoodSelectScript>().isPaused = false;

        GameObject.Find("Music_Player").GetComponent<AudioSource>().volume = 0.723f;

        pauseButton.GetComponent<PauseScript>().isPaused = false;
        Debug.Log("Unpaused!");
    }
}
