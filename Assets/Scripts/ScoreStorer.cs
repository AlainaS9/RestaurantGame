using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorer : MonoBehaviour
{
    // Start is called before the first frame update

    public int hiScore;

    void Start()
    {
        if (PlayerPrefs.HasKey("hiScore"))
        {
            hiScore = (int)PlayerPrefs.GetFloat("hiScore");
        }
        else
        {
            PlayerPrefs.SetFloat("hiScore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newHiScore(int points)
    {
        if (points > hiScore)
        {
            PlayerPrefs.SetFloat("hiScore", points);
            hiScore = (int)PlayerPrefs.GetFloat("hiScore");
        }
    }
}
