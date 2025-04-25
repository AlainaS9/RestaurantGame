using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CustomerScript : MonoBehaviour
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

        Debug.Log("Select Object is " + selectObject);
    }

    // Update is called once per frame
    void Update()
    {
        changeSprite();
    }

    public void setWanted()
    {
        setCustomer();
        wantedNum = (int)(Random.Range(1.0f, 4.0f));

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
            if (!isAlien)
            {
                GameObject.Find("Point_Storer").GetComponent<PointController>().points =
                        (int)(GameObject.Find("Point_Storer").GetComponent<PointController>().points +
                        (GameObject.Find("Timer_Graphic").GetComponent<TimerScript>().timeLeft * 10));
            }
            else
            {
                GameObject.Find("Point_Storer").GetComponent<PointController>().points =
                (GameObject.Find("Point_Storer").GetComponent<PointController>().points + 500);
            }



            if(linePosition == 0)
            {
                GameObject.Find("Customer_Spawner_Left").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else if (linePosition == 1)
            {
                GameObject.Find("Customer_Spawner_Middle").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else if (linePosition == 2)
            {
                GameObject.Find("Customer_Spawner_Right").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else
            {
                Debug.Log("ERROR with line position");
            }

            audioSource.Play();
            Debug.Log("Play audio serve");

            selectObject.GetComponent<FoodSelectScript>().isEnabled = true;
            customerSelector.GetComponent<CustomerSelectScript>().isEnabled = false;
            selectObject.GetComponent<FoodSelectScript>().selected = null;

            Destroy(gameObject);
        }
        else
        {
            incorrectServe(false);
        }
    }

    public void incorrectServe(bool isTimeFail)
    {
        Debug.Log("Incorrect!");

        if (!isTimeFail)
        {
            selectObject.GetComponent<FoodSelectScript>().isEnabled = true;
            customerSelector.GetComponent<CustomerSelectScript>().isEnabled = false;
            selectObject.GetComponent<FoodSelectScript>().selected = null;

            if (linePosition == 0)
            {
                GameObject.Find("Customer_Spawner_Left").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else if (linePosition == 1)
            {
                GameObject.Find("Customer_Spawner_Middle").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else if (linePosition == 2)
            {
                GameObject.Find("Customer_Spawner_Right").GetComponent<CreateCustomer>().isCustomerHere = false;
            }
            else
            {
                Debug.Log("ERROR with line position");
            }

        }
        // GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
        Destroy(gameObject);

        GameObject.Find("Health").GetComponent<HealthScript>().health--;
        GameObject.Find("Health").GetComponent<HealthScript>().updateSprites();
    }
    void setCustomer()
    {
        customerType = (int)(Random.Range(1.0f, 4.0f));
        if ((int)Random.Range(1.0f, 21.0f) < 2) {
            isAlien = true;
            customerType = 4;
        }
        else if (GameObject.Find("Point_Storer").GetComponent<PointController>().points > 2500 && (int)Random.Range(1.0f, 21.0f) < 8)
        {
            isAlien = true;
            customerType = 4;
        }
        else
        {
            isAlien = false;
        }
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
}
