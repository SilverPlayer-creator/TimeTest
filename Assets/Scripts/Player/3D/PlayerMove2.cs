using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public TimeManager manager;
    public CharacterController controller;

    public float speed = 12; //hur snabbt spelaren rör sig
    public float gravity = -9.18f; //hur snabbt spelaren faller
    public float jumpHeight = 3; //hur högt spelaren hoppar

    public Transform groundCheck; //botten av spelaren
    public float groundDistance = 0.4f; //avståndet till marken
    public LayerMask groundMask; //avgör vad mark är
    bool isGrounded = false; //om spelaren är på marken
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //om mark hittas är spelaren grounded

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.unscaledDeltaTime);

        //hoppa
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.unscaledDeltaTime;

        controller.Move(velocity * Time.unscaledDeltaTime);
    }
}
