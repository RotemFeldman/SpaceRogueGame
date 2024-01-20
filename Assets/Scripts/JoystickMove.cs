using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCooldownCounter;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = playerSpeed;
    }
    private void FixedUpdate()
    {
        if (movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * activeMoveSpeed, movementJoystick.Direction.y * activeMoveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            dashCooldownCounter = dashCooldown;
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = playerSpeed;
            }
        }
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
    }
}