using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
        public float timerLength;
        public float timeLeft;


    public SpriteRenderer spriteRenderer;
    public Sprite full;
    public Sprite threeQuarters;
    public Sprite half;
    public Sprite oneQuarter;
    public Sprite empty;

    void Start()
        {
        timeLeft = timerLength;
        }
    void Update()
        {
        //CHANGE THIS AT SOME POINT, NOT JUST HAVE IT BE IN UPDATE
            if (timeLeft > 0)
            {
                if(timeLeft >= timerLength)
            {
                spriteRenderer.sprite = full;
            }
            else if(timeLeft <= ((timerLength * 3) / 4) && (timeLeft > (timerLength / 2)))
            {
                spriteRenderer.sprite = threeQuarters;
            }
            else if (timeLeft <= (timerLength / 2) && (timeLeft > (timerLength / 4)))
            {
                spriteRenderer.sprite = half;
            }
            else if (timeLeft <= (timerLength / 4) && timeLeft > 0)
            {
                spriteRenderer.sprite = oneQuarter;
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
            GetComponentInParent<CustomerScript>().incorrectServe();
        }
        }
    }
