using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]

    public Sprite sprite1d; // Drag your first sprite here
    public Sprite sprite2d; // Drag your second sprite here


    public static bool open_door = false;
    //private bool prefab_onn = false;


    private SpriteRenderer spriteRenderer_d;

    void Start()


    {
        if (ExitLevel.ii == 2)
        {
            open_door = false;
        }




        spriteRenderer_d = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer_d.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer_d.sprite = sprite1d; // set the sprite to sprite1
    }

    void Update()
    {



        //if (Input.GetKeyDown(KeyCode.Z)) // If the space bar is pushed down
        if (open_door)
        {
            //ChangeTheDamnSprite(); // call method to change sprite
            spriteRenderer_d.sprite = sprite2d;
            //Instantiate(_items);
            //prefab_onn = true;

        }


    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer_d.sprite == sprite1d) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer_d.sprite = sprite2d;
        }
        else
        {
            spriteRenderer_d.sprite = sprite1d; // otherwise change it back to sprite1
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && PlayerMove.hasKey )
        {
            open_door = true;
         
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        open_door = false;
    }



}

