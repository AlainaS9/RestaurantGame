using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerSelectScript : MonoBehaviour
{

    public int selectedNum;
    public int upperLimit;
    public int lowerLimit;
    public GameObject selected;
    public bool isEnabled;
    public bool isPaused;
    public GameObject foodSelector;
    public SpriteRenderer spriteRenderer;
    public Sprite visible;
    public Sprite invisible;

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = false;
        spriteRenderer.sprite = invisible;
        selectedNum = 0;
        transform.position = GameObject.Find("Customer_Spawner_Left").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && !isPaused)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (selectedNum > lowerLimit)
                {
                    selectedNum--;
                    //   Select();
                    transform.position = transform.position + new Vector3(-6.0f, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (selectedNum < upperLimit)
                {
                    selectedNum++;
                    //   Select();
                    transform.position = transform.position + new Vector3(6.0f, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Serve();
            }

        }
    }
/*
    public void Select()
    {
        //sets the GameObject selected to the object that is currently hovered over

        selected = GameObject.Find("Customer_Controller").GetComponent<CustomerSpawnControl>().customersArray[selectedNum];

        Debug.Log(selected);

        while (selected == null)
        {
            spriteRenderer.sprite = invisible;
            selectedNum++;
            Debug.Log(selectedNum);
            if (selectedNum > upperLimit)
            {
                selectedNum = lowerLimit;
            }
            selected = GameObject.Find("Customer_Controller").GetComponent<CustomerSpawnControl>().customersArray[selectedNum];
        }
        transform.position = selected.transform.position;
        if (selected != null)
        {
            spriteRenderer.sprite = visible;
        }
    }
*/

    void Serve()
    {
        selected = GameObject.Find("Customer_Controller").GetComponent<CustomerSpawnControl>().customersArray[selectedNum];
        if (selected != null)
        {
            if (SceneManager.GetActiveScene().name == "TutorialScene")
            {
                selected.GetComponent<TutorialCustomer>().checkServe();
            }
            else
            {
                selected.GetComponent<CustomerScript>().checkServe();
            }
            isEnabled = false;

            foodSelector.GetComponent<FoodSelectScript>().appear();
            foodSelector.GetComponent<FoodSelectScript>().isEnabled = true;
            foodSelector.GetComponent<FoodSelectScript>().Select();

            spriteRenderer.sprite = invisible;
        }
    }

    public void appear()
    {
        spriteRenderer.sprite = visible;
    }

}
