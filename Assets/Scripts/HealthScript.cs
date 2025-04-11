using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int health;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            endGame();
        }
    }

    void endGame()
    {
        DontDestroyOnLoad(GameObject.Find("Point_Storer"));
        SceneManager.LoadScene("GameOverScene");
    }

    public void updateSprites()
    {
        switch (health)
        {
            case 1:
                GameObject.Find("HP_Heart2").GetComponent<HeartSpriteScript>().deplete();
                GameObject.Find("HP_Heart3").GetComponent<HeartSpriteScript>().deplete();
                break;
            case 2:
                GameObject.Find("HP_Heart3").GetComponent<HeartSpriteScript>().deplete();
                break;
        }

        Debug.Log("Play audio fail");
        audioSource.Play();
    }
}
