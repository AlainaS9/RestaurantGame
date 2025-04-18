using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{

    public Sprite tutorial_1;
    public Sprite tutorial_2;
    public Sprite tutorial_3;
    public Sprite tutorial_4;
    public Sprite tutorial_5;
    public Sprite tutorial_6;
    public SpriteRenderer spriteRenderer;

    public int tutorialNumber;
    private bool tutorialOnScreen;

    public GameObject customerSelector;
    public GameObject foodSelector;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.transform.localScale = new Vector3(0.8320917f, 0.8320917f, 1);
        tutorialNumber = 1;
        NextTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tutorialOnScreen)
        {
            if (tutorialNumber < 5)
            {
                TutorialOff();
            }
            else
            {
                NextTutorial();
            }
        }
    }

    public void NextTutorial()
    {
        tutorialOnScreen = true;
        Time.timeScale = 0;
        customerSelector.GetComponent<CustomerSelectScript>().isPaused = true;
        foodSelector.GetComponent<FoodSelectScript>().isPaused = true;

        switch (tutorialNumber)
        {
            case 1:
                spriteRenderer.sprite = tutorial_1;
                break;
            case 2:
                spriteRenderer.sprite = tutorial_2;
                break;
            case 3:
                spriteRenderer.sprite = tutorial_3;
                break;
            case 4:
                spriteRenderer.sprite = tutorial_4;
                break;
            case 5:
                spriteRenderer.sprite = tutorial_5;
                break;
            case 6:
                spriteRenderer.sprite = tutorial_6;
                break;
            case 7:
                SceneManager.LoadScene("GameScene");
                break;
        }

        tutorialNumber++;
    }

    public void TutorialOff()
    {
        Time.timeScale = 1;
        customerSelector.GetComponent<CustomerSelectScript>().isPaused = false;
        foodSelector.GetComponent<FoodSelectScript>().isPaused = false;
        spriteRenderer.enabled = false;
    }
}
