using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorer : MonoBehaviour
{
    // Start is called before the first frame update

    public int hiScore;

    void Start()
    {
        hiScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newHiScore(int points)
    {
        if (points > hiScore)
        {
            hiScore = points;
        }
    }
}
