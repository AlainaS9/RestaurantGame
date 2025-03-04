using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCustomer : MonoBehaviour
{
    private int foodWanted;
    private int patienceForms;
    //impatient, moderate, and patient

    public float timeBetweenCustomers;

    public bool isCustomerHere;
    private int patience;
    private int linePosition;
    private int lineLength;
    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
        //temporary framerate just for testing performance
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
        // linePosition = (int)(Random.Range(1.0f, 3.0f));

        GameObject newCustomer = Instantiate(customer);

        newCustomer.GetComponent<CustomerScript>().setWanted();

    }
}
