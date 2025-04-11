using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelectScript : MonoBehaviour
{

    public int selectedNum;
    public int upperLimit;
    public int lowerLimit;
    public GameObject selected;
    public bool isEnabled;
    public bool isPaused;
    public GameObject customerSelector;
    public SpriteRenderer spriteRenderer;
    public Sprite visible;
    public Sprite invisible;

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true;
        selectedNum = 1;
        Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && !isPaused) { 
           if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
            if(selectedNum > lowerLimit)
            {
                selectedNum--;
                Select();
                transform.position = selected.transform.position;
            }
        }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (selectedNum < upperLimit)
                {
                    selectedNum++;
                    Select();
                    transform.position = selected.transform.position;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                ChooseFood();
            }
        }
    }

    public void Select()
    {
        //sets the GameObject selected to the object that is currently hovered over
            switch (selectedNum)
            {
                case 1:
                    selected = GameObject.Find("Food_1");
                    break;
                case 2:
                    selected = GameObject.Find("Food_2");
                    break;
                case 3:
                    selected = GameObject.Find("Food_3");
                    break;
            }
    }

    void ChooseFood()
    {
        isEnabled = false;

        customerSelector.GetComponent<CustomerSelectScript>().appear();
        customerSelector.GetComponent<CustomerSelectScript>().isEnabled = true;
       // customerSelector.GetComponent<CustomerSelectScript>().Select();

        spriteRenderer.sprite = invisible;
    }

    public void appear()
    {
        spriteRenderer.sprite = visible;
    }
}
