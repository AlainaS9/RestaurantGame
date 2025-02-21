using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedSprites : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite foodOption1;
    public Sprite foodOption2;
    // public Sprite foodOption3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFood(int foodType)
    {
        switch (foodType)
        {
            case 1:
                spriteRenderer.sprite = foodOption1;
                break;
            case 2:
                spriteRenderer.sprite = foodOption2;
                break;
        /*    case 3:
                spriteRenderer.sprite = customerOption3;
                break;
        */
        }
    }
}
