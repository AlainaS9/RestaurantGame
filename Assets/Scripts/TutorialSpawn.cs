using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawn : MonoBehaviour
{
    public bool isCustomerHere;
    public GameObject customer;
    public GameObject tutorialHandler;
    // Start is called before the first frame update
    void Start()
    {
        isCustomerHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCustomerHere)
        {
            Invoke("Spawn", 1.0f);
            Invoke("ActivateTutorial", 1.01f);
            isCustomerHere = true;
        }
    }

    void Spawn()
    {
        GameObject newCustomer = Instantiate(customer);
        GameObject.Find("Customer_Controller").GetComponent<CustomerSpawnControl>().customersArray[1] = newCustomer;

        newCustomer.GetComponent<TutorialCustomer>().setWanted();

        newCustomer.transform.position = gameObject.transform.position;
        newCustomer.GetComponent<TutorialCustomer>().linePosition = 1;
    }

    public void ActivateTutorial()
    {
        tutorialHandler.GetComponent<SpriteRenderer>().enabled = true;
        tutorialHandler.GetComponent<TutorialHandler>().NextTutorial();
    }
}
