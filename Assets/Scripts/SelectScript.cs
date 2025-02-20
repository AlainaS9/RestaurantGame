using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{

    public int selectedNum;
    public int upperLimit;
    public int lowerLimit;
    public GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        selectedNum = 1;
        Select();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void Select()
    {
        //sets the GameObject selectedFood to the object that is currently hovered over
        switch(selectedNum)
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
}
