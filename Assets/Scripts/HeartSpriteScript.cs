using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpriteScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite depleted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deplete()
    {
        spriteRenderer.sprite = depleted;
    }
}
