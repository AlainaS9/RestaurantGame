using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(goToScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void goToScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
