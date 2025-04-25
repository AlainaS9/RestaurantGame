using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
        public float timerLength;
        public float timeLeft;


    public SpriteRenderer spriteRenderer;
    public Sprite full;
    public Sprite sevenEighths;
    public Sprite threeQuarters;
    public Sprite fiveEighths;
    public Sprite half;
    public Sprite threeEighths;
    public Sprite oneQuarter;
    public Sprite oneEighth;
    public Sprite empty;

    void Start()
        {

        }
    void Update()
        {
            if (timeLeft > 0)
            {
                if(timeLeft >= timerLength)
            {
                spriteRenderer.sprite = full;
            }
            else if (timeLeft <= ((timerLength * 7) / 8) && timeLeft > (timerLength * 3) / 4)
            {
                spriteRenderer.sprite = sevenEighths;
            }
            else if(timeLeft <= ((timerLength * 3) / 4) && timeLeft > ((timerLength * 5) / 8))
            {
                spriteRenderer.sprite = threeQuarters;
            }
            else if (timeLeft <= ((timerLength * 5) / 8) && timeLeft > timerLength / 2)
            {
                spriteRenderer.sprite = fiveEighths;
            }
            else if (timeLeft <= (timerLength / 2) && timeLeft > ((timerLength * 3) / 8))
            {
                spriteRenderer.sprite = half;
            }
            else if (timeLeft <= ((timerLength * 3) / 8) && timeLeft > timerLength / 4)
            {
                spriteRenderer.sprite = threeEighths;
            }
            else if (timeLeft <= (timerLength / 4) && timeLeft > ((timerLength * 1) / 8))
            {
                spriteRenderer.sprite = oneQuarter;
            }
            else if (timeLeft <= ((timerLength * 1) / 8) && timeLeft > 0)
            {
                spriteRenderer.sprite = oneEighth;
            }
            else if (timeLeft <= 0)
            {
                spriteRenderer.sprite = empty;
            }

            timeLeft -= Time.deltaTime;
              //  Debug.Log((int)timeLeft);
            }
            if(timeLeft <= 0)
            {
            GetComponentInParent<CustomerScript>().incorrectServe(true);
        }
        }

    public void setTime()
    {
        if (GameObject.Find("Point_Storer").GetComponent<PointController>().points < 1000)
        {
            timeLeft = Random.Range(10.0f, 15.0f);
            
        }
        else if (GameObject.Find("Point_Storer").GetComponent<PointController>().points >= 1000 && GameObject.Find("Point_Storer").GetComponent<PointController>().points < 3000)
        {
            timeLeft = Random.Range(5.0f, 10.0f);
        }
        else if (GameObject.Find("Point_Storer").GetComponent<PointController>().points >= 3000)
        {
            timeLeft = Random.Range(2.0f, 5.0f);
        }

        if(GetComponentInParent<CustomerScript>().isAlien)
        {
            timeLeft = 1.5f;
        }

        timerLength = timeLeft;


      //  Debug.Log("Time length is" + timeLeft);
    }
    }
