using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialCustomer : MonoBehaviour
{
    public int wantedNum;
    private GameObject wantedFood;
    public int patience;
    public GameObject selectObject;
    public GameObject customerSelector;

    public SpriteRenderer spriteRenderer;
    public Sprite customerOption1;
    public Sprite customerOption2;
    public Sprite customerOption3;
    public Sprite customerOptionAlien;
    private int customerType;
    public bool isAlien;

    public int linePosition;

    AudioSource audioSource;

    public float volume = 0.5f;

    public GameObject tutorialHandler;

    /*
    public enum linePosition
    {
        left,
        middle,
        right
    }
    */


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("SFX_Player").GetComponent<AudioSource>();
        selectObject = GameObject.Find("Food_Select_Outline");
        customerSelector = GameObject.Find("Customer_Select_Outline");
        tutorialHandler = GameObject.Find("Tutorial_Images");
    }

    // Update is called once per frame
    void Update()
    {
        changeSprite();
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && GameObject.Find("Food_Select_Outline").GetComponent<FoodSelectScript>().isEnabled)
        {
            GameObject.Find("Food_Select_Outline").GetComponent<FoodSelectScript>().isEnabled = false;
            GameObject.Find("Customer_Select_Outline").GetComponent<CustomerSelectScript>().isEnabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && GameObject.Find("Food_Select_Outline").GetComponent<CustomerSelectScript>().isEnabled)
        {
            wantedFood = selectObject.GetComponent<CustomerSelectScript>().selected;
        }
        */
    }

    public void setWanted()
    {
        setCustomer();
        wantedNum = 2;

        switch (wantedNum)
        {
            case 1:
                wantedFood = GameObject.Find("Food_1");
                break;
            case 2:
                wantedFood = GameObject.Find("Food_2");
                break;
            case 3:
                wantedFood = GameObject.Find("Food_3");
                break;
        }
        Debug.Log(wantedNum + " and " + wantedFood);

        // GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = true;

        GetComponentInChildren<WantedSprites>().setFood(wantedNum);

    }

    public void checkServe()
    {
        // wantedFood = selectObject.GetComponent<FoodSelectScript>().selected;
        if (selectObject.GetComponent<FoodSelectScript>().selected == wantedFood)
        {
            Debug.Log("Correct!");
            GameObject.Find("Point_Storer").GetComponent<PointController>().points =
                    (int)(GameObject.Find("Point_Storer").GetComponent<PointController>().points +
                    (GameObject.Find("Timer_Graphic").GetComponent<TimerScript>().timeLeft * 10));

            audioSource.Play();
            Debug.Log("Play audio serve");

            selectObject.GetComponent<FoodSelectScript>().isEnabled = true;
            customerSelector.GetComponent<CustomerSelectScript>().isEnabled = false;
            selectObject.GetComponent<FoodSelectScript>().selected = null;

            ActivateTutorial();

            Destroy(gameObject);
        }
        else
        {
            incorrectServe();
        }
    }

    public void incorrectServe()
    {
        Debug.Log("Incorrect!");

        selectObject.GetComponent<FoodSelectScript>().isEnabled = true;
        customerSelector.GetComponent<CustomerSelectScript>().isEnabled = false;
        selectObject.GetComponent<FoodSelectScript>().selected = null;

        Destroy(gameObject);
    }
    void setCustomer()
    {
        customerType = (int)(Random.Range(1.0f, 4.0f));
        changeSprite();
    }

    void changeSprite()
    {
        switch (customerType)
        {
            case 1:
                spriteRenderer.sprite = customerOption1;
                break;
            case 2:
                spriteRenderer.sprite = customerOption2;
                break;
            case 3:
                spriteRenderer.sprite = customerOption3;
                break;
            case 4:
                spriteRenderer.sprite = customerOptionAlien;
                break;
        }
    }

    void ActivateTutorial()
    {
        tutorialHandler.GetComponent<SpriteRenderer>().enabled = true;
        tutorialHandler.GetComponent<TutorialHandler>().NextTutorial();
    }
}
