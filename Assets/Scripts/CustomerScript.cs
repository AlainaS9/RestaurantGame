using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CustomerScript : MonoBehaviour
{
    public int wantedNum;
    private GameObject wantedFood;
    public int patience;
    public GameObject selectObject;
    public int linePosition;
  //  private int timer;

    // Start is called before the first frame update
    void Start()
    {
       
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
        if (linePosition == 1)
        {
            //timer decreases every second
        }
    }

    public void setWanted()
    {
        wantedNum = (int)(Random.Range(1.0f, 3.0f));
        Debug.Log(wantedNum + " and " + wantedFood);

    //    GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = true;
        switch (wantedNum)
        {
            case 1:
                wantedFood = GameObject.Find("Food_1");
                GameObject.Find("Customer_Want").GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                wantedFood = GameObject.Find("Food_2");
                GameObject.Find("Customer_Want").GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 3:
                GameObject.Find("Customer_Want").GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }

    void checkServe()
    {
        if (selectObject.GetComponent<SelectScript>().selected == wantedFood)
        {
            Debug.Log("Correct!");
            GameObject.Find("Point_Storer").GetComponent<PointController>().points =
                    (int)(GameObject.Find("Point_Storer").GetComponent<PointController>().points + 
                    (GameObject.Find("Customer_Want").GetComponent<TimerScript>().timeLeft * 10));

            GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
            Destroy(GameObject.Find("Customer"));
        }
        else
        {
            Debug.Log("Incorrect!");
            GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
            Destroy(GameObject.Find("Customer"));
        }
    }
}
