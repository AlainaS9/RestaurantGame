using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Exit_Button")
        {
            gameObject.SetActive(false);
        }
        button.onClick.AddListener(returnToStart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void returnToStart ()
    {
        SceneManager.LoadScene("StartMenu");
        if (gameObject.name == "Return_Button")
        {
            DontDestroyOnLoad(GameObject.Find("Score_Storer"));
        }
    }
}
