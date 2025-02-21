using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Point_Storer").GetComponent<PointController>().points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points = GameObject.Find("Point_Storer").GetComponent<PointController>().points;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
    }
}
