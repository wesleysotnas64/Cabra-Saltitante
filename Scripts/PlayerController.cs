using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController character;
    public float maxHeight;
    public float jumpSpeed;
    public float timeToPeak;
    public float gravity;
    public Vector2 yVelocity;
    public Vector2 vDirection;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        GravityInit();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GravityRun();
        if(Input.GetKeyDown("a"))
            LeftJump();
        else if(Input.GetKeyDown("d"))
            RightJump();
    }

    public void LeftJump()
    {
        spriteRenderer.flipX = true;

        Vector2 invert = vDirection;
        invert.x *= -1;
        yVelocity = jumpSpeed * invert.normalized;
    }

    public void RightJump()
    {
        spriteRenderer.flipX = false;
        yVelocity = jumpSpeed * vDirection.normalized;
    }

    private void GravityInit()
    {
        character = GetComponent<CharacterController>();
        gravity = 2*maxHeight / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;
    }

    private void GravityRun()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down;
        character.Move(yVelocity * Time.deltaTime);
    }
}
