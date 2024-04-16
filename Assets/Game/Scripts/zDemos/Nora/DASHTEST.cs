using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHTEST : MonoBehaviour
{
    bool DashReady = true;
    Rigidbody2D RB;
    float speed = 2, FacingDirection;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && DashReady)
        {
            DashReady = false;
            Invoke("ReadyUpDash", 2);
            RB.AddForce(new Vector2((RB.velocity.x + speed) * FacingDirection, RB.velocity.y), ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            FacingDirection = -1;
            RB.MovePosition(new Vector2((RB.position.x + speed) * FacingDirection, RB.velocity.y)); //minus 1 = inverted
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            FacingDirection = 1;
            RB.MovePosition(new Vector2((RB.position.x + speed), RB.velocity.y));
        }
    }

    void ReadyUpDash()
    {
        DashReady = true;
    }

}
