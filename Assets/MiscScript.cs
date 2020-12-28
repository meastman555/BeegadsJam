using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScript : MonoBehaviour
{

    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite altSprite;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {  
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }

    public void EasterEgg() {
        spriteRenderer.sprite = altSprite;
    }
}
