using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour
{
    public GameObject pointText;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
    }
}
