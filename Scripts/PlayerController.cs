using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    public Vector2 forceJump;
    public bool jumping;
    public bool onRock;
    public bool onGround;

    public GroundCheck groundCheck;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        groundCheck = this.gameObject.transform.GetChild(0).gameObject.GetComponent<GroundCheck>();
    }

    void Update()
    {
        UpdateGroundCheck();
        KeyboardJoystick();
    }

    private void UpdateGroundCheck()
    {
        onGround = groundCheck.OnGround;
        onRock = groundCheck.OnRock;
    }

    private void KeyboardJoystick()
    {
        if (Input.GetKeyDown("a")) LeftJump();
        else if (Input.GetKeyDown("d")) RightJump();
    }

    private void Jump(int direction)
    {
        if(onGround || onRock)
            rigidBody.velocity = new Vector2(forceJump.x * direction, forceJump.y);
    }

    public void LeftJump()
    {
        spriteRenderer.flipX = true;
        Jump(-1);
    }

    public void RightJump()
    {
        spriteRenderer.flipX = false;
        Jump(1);
    }

}
