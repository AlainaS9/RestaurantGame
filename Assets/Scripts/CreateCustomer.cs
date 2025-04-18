using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCustomer : MonoBehaviour
{
    public float timeBetweenCustomers;

    public bool isCustomerHere;
    public GameObject customer;

    public int linePosition;


    public AudioSource audioSource;
    /*
    public enum linePosition
    {
        left,
        middle,
        right
    }
    */

    // List<GameObject> customersList;


    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
        //temporary framerate just for testing performance

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCustomerHere)
        {
            isCustomerHere = true;
            Invoke("Spawn", timeBetweenCustomers);
        }
    }

    void Spawn()
    {
        GameObject newCustomer = Instantiate(customer);
        newCustomer.name = "Customer" + linePosition;
        GameObject.Find("Customer_Controller").GetComponent<CustomerSpawnControl>().customersArray[linePosition] = newCustomer;

        Debug.Log(linePosition + " is " + newCustomer);

        newCustomer.GetComponent<CustomerScript>().setWanted();
        newCustomer.GetComponentInChildren<TimerScript>().setTime();

        newCustomer.transform.position = gameObject.transform.position;
        newCustomer.GetComponent<CustomerScript>().linePosition = linePosition;

        Debug.Log("Play audio");
        audioSource.Play();
        isCustomerHere = true;
    }
}
