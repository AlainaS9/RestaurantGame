using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
        public float timerLength;
        public float timeLeft;

    void Start()
        {
        timeLeft = timerLength;
        }
    void Update()
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
              //  Debug.Log((int)timeLeft);
            }
            if(timeLeft <= 0)
            {
                Destroy(GameObject.Find("Customer"));
            GameObject.Find("Customer_Spawner").GetComponent<CreateCustomer>().isCustomerHere = false;
        }
        }
    }
