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
        gameObject.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
