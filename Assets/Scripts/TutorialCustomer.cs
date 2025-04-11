using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCustomer : MonoBehaviour
{
    public bool isCustomerHere;
    public GameObject customer;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject newCustomer = Instantiate(customer);

        newCustomer.GetComponent<CustomerScript>().setWanted();
        newCustomer.GetComponentInChildren<TimerScript>().setTime();

        newCustomer.transform.position = gameObject.transform.position;

    }
}
