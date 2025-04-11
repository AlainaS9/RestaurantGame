using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
            button.onClick.AddListener(endGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void endGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
