using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    private int points;
    void Start()
    {
        points = GameObject.Find("Point_Storer").GetComponent<PointController>().points;
        if (gameObject.name == "ScoreText")
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + points;
        }
        else
        {
            GameObject.Find("Score_Storer").GetComponent<ScoreStorer>().newHiScore(points);
            gameObject.GetComponent<TextMeshProUGUI>().text = "Hi Score: " + GameObject.Find("Score_Storer").GetComponent<ScoreStorer>().hiScore;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
