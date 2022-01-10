using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;                     //скольжение камеры
    public Vector2 offset = new Vector2(2f, 1f);      //смещение камеры относительно персонажа по  x y
    public bool isLeft;                              //проверка на взгляд влево
    private Transform player;                        //определяет положенеи нашего персонажа
    private int lastX;                               //в какую сторону в последнйи раз смотрел персонаж ,чтобы камера оставалась в том направлении


    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);   //математическое вычисленеи смещения
        FindPlayer(isLeft);


    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    //поиск персонажа по тегу плеер
        lastX = Mathf.RoundToInt(player.position.x);// строка позволит работать по оси Х

        if (playerIsLeft) //если наш персонаж действительно смотри влево , то камера должна сместиться относительно нашего персонажа, вычитая  указанное нами смещение
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);

        }

        else 
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); 
            // если нас персонаж смотрит не влево а впрово, то камера смещается в другую (положительную) сторону
        }





    }


    private void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x); //считывание положение камеры по Х относительно нашео персонажа

            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;

            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft) 
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping*Time.deltaTime);
            transform.position = currentPosition;






        }
    }



}





