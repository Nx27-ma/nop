using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHTEST : MonoBehaviour
{
    bool DashReady = true;
    Rigidbody2D RB;
    float speed = 2;
    int FacingDirection;
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

        if(Input.GetKeyDown())
    }

    void ReadyUpDash()
    {
        DashReady = true;
    }

}
