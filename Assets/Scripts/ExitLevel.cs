using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    
    [SerializeField] private int nextLavelIndex;
    //int ii = SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public static int ii;

    private void Start()
    {

        Screen.SetResolution(800, 600, false);
        // int ii = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log("\nActive Scene index:___при старте " + ii);
    }

    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        int ii = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("\nActive Scene index:___при проверке триггера " + ii);

        if (collision.gameObject.tag == "Player")


        {
            if (ii == 2)
            {
                LastChangeScene();
                //Debug.Log("\nActive Scene index:___!!!!!!!!!!!!___ " + ii);
            }

            if(ii<2 && Door.open_door)
            {
                ChangeScene();
                //Debug.Log("\nActive Scene index: " + ii);
            }
        }

    }

    private void ChangeScene() 
    {
        SceneManager.LoadScene(2);
       
    }

    private void LastChangeScene()
    {
        SceneManager.LoadScene(3);
    }

}
