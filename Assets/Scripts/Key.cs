using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private bool isFollowing= false;
    public float followSpeed;
    public Transform followTarget;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.hasKey)
        {
            //PlayerMove thePlayer = FindObjectOfType<PlayerMove>();
           //followTarget = thePlayer.keyFollowPoint;

            isFollowing = true;
            //thePlayer.followingKey = this;
            
        }



        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed*Time.deltaTime);
        }
    }

   
}
