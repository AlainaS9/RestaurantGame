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
    public int linePosition;


    public SpriteRenderer spriteRenderer;
    public Sprite customerOption1;
    public Sprite customerOption2;
    public Sprite customerOption3;
    private int customerType;

    // Start is called before the first frame update
    void Start()
    {
        selectObject = GameObject.Find("Select_Outline");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(selectObject.GetComponent<SelectScript>().selected);
            Debug.Log("Checking serve");
            checkServe();
        }
    }

    public void setWanted()
    {
        setCustomer();
        wantedNum = (int)(Random.Range(1.0f, 3.0f));

        switch (wantedNum)
        {
            case 1:
                wantedFood = GameObject.Find("Food_1");
                break;
            case 2:
                wantedFood = GameObject.Find("Food_2");
                break;
        }
                Debug.Log(wantedNum + " and " + wantedFood);

       // GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = true;

        GameObject.Find("Wanted_Food").GetComponent<WantedSprites>().setFood(wantedNum);
        
    }

    void checkServe()
    {
        if (selectObject.GetComponent<SelectScript>().selected == wantedFood)
        {
            Debug.Log("Correct!");
            GameObject.Find("Point_Storer").GetComponent<PointController>().points =
                    (int)(GameObject.Find("Point_Storer").GetComponent<PointController>().points + 
                    (GameObject.Find("Timer_Graphic").GetComponent<TimerScript>().timeLeft * 10));

            GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
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
        // GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
        Destroy(gameObject);

        //FOR MVP: END GAME
        DontDestroyOnLoad(GameObject.Find("Point_Storer"));
        SceneManager.LoadScene("GameOverScene");
    }
    void setCustomer()
    {
        customerType = (int)(Random.Range(1.0f, 4.0f));
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
        }
    }
}
