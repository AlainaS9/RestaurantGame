using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame()
    {
        Debug.Log("pushed!");
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
            if (gameObject.name == "Restart_Button") 
        {
            DontDestroyOnLoad(GameObject.Find("Score_Storer"));
        }
    }
}
