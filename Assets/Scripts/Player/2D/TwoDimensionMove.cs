using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionMove : MonoBehaviour
{
    public TimeManager manager;

    public float Speed = 12; //hur snabbt spelaren rör sig
    public float Gravity = -9.18f; //hur snabbt spelaren faller
    public float JumpForce = 3; //hur högt spelaren hoppar
    public float NormalJumpForce;
    public float FastJumpForce; //hur högt spelaren hoppar när tiden är ökad
    public float SlowJumpForce; //hur högt spelaren hoppar när tiden är nedsaktad
    float NormalTime;
    float SlowTime;
    float FastTime;
    public float currentTime;
    public bool isJumping = false;
    public bool isGrounded; //om spelaren är på marken

    public Rigidbody2D RB;

    Vector2 Velocity;
    // Start is called before the first frame update
    void Start()
    {
        NormalJumpForce = JumpForce;
        FastJumpForce = JumpForce / 2;
        SlowJumpForce = JumpForce * 2;
        NormalTime = Time.timeScale;
        FastTime = Time.timeScale * 2;
        SlowTime = Time.timeScale / 2;
        RB = GetComponent<Rigidbody2D>();
        Gravity = RB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Movement * Speed * Time.unscaledDeltaTime;

        Velocity.y += Gravity * Time.unscaledDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (manager.isSlowing) //if time is slowing down
        {
            JumpForce = SlowJumpForce; //increase the players jump force to combat the SlowTime
        }
        if (manager.isSpeedingUp) //if time is speeding up
        {
            JumpForce = FastJumpForce; //decrease the players jump force to combat the FastTime
        }
        else if (manager.isNormal)
        {
            JumpForce = NormalJumpForce;
        }
    }
    private void FixedUpdate()
    {

    }
    void Jump()
    {
            RB.AddForce(new Vector2(0, Input.GetAxis("Jump")) * JumpForce * Time.unscaledDeltaTime, ForceMode2D.Impulse);
    }
}
