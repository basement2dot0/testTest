using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFootController : Controller
{
    //movement information
    Vector3 walkVelocity;
    float adjVertVeolcity;

    //Settings
    public float speed = 3f;
    public float jumpSpeed = 6f;

    public override void ReadInput(InputData data)
    {
        walkVelocity = Vector3.zero;
        

        //set vertical movement

        if (data.axes[0] != 0f)
            walkVelocity += Vector3.forward * data.axes[0] * speed;

        //set horizontal movement
        if (data.axes[1] != 0f)
            walkVelocity += Vector3.right * data.axes[1] * speed;


        newInput = true;


    }

    private void LateUpdate()
    {
        if (!newInput)
            walkVelocity = Vector3.zero;

        rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y, walkVelocity.z);
        newInput = false;
    }
}
