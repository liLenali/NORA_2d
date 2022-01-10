using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunduk : MonoBehaviour
{
    [SerializeField] private Item _items;

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here


    public bool sunduk = false;
    //private bool prefab_onn = false;


    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z)) // If the space bar is pushed down
        if (sunduk == true && Input.GetKeyDown(KeyCode.E))
        {
            //ChangeTheDamnSprite(); // call method to change sprite
            spriteRenderer.sprite = sprite2;
            Instantiate(_items);
            //prefab_onn = true;

        }


    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag.Equals("Player"))
        {
        sunduk = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sunduk = false;
    }



}
