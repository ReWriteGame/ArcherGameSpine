using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField][Range(0, 50)] private float accelerationSpeed = 10;
    [SerializeField][Range(0, 20)] private float jumpForce = 1;
    [SerializeField][Range(0, 5)]  private float jumpBoost = 0;

    #region events, properties and fields
    
    private bool canMove = true;
    private bool canJump = false;
    
    private bool isMoving = false;
    private bool isJumping = false;

    private float speed;
    private Rigidbody2D rb;

    public Action OnMoveRight;
    public Action OnMoveLeft;
    public Action OnIdle;
    public Action OnJump;
    public Action OnFall;

    #endregion

    public bool IsMoving { get => isMoving; }
    public bool IsJumping { get => isJumping; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanJump { get => canJump; set => canJump = value; }
    public float Speed { get => speed; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void RightMove()
    {
        speed = accelerationSpeed;
        isMoving = true;
        if(canMove)OnMoveRight?.Invoke();
    }
    
    public void LeftMove()
    {
        speed = -accelerationSpeed;
        isMoving = true;
        if(canMove)OnMoveLeft?.Invoke();

    }
    
    public void StopMove()
    {
        speed = 0;
        isMoving = false;
        OnIdle?.Invoke();
    }


    public void Jump()
    {
        if(canJump)isJumping = true;
    }
    
    public void StopJump()
    {
      isJumping = false;
    }

    private void MoveLogic()
    {
        if (canMove)
        {
            float xVelocity, yVelocity;
            xVelocity = speed;
            yVelocity = rb.velocity.y;

            Vector2 force = new Vector2(xVelocity, yVelocity);
            rb.AddForce(rb.mass * force);
        }
    }
    
    private void JumpLogic()
    {
        if (canJump && isJumping)
        {
            Vector2 force = new Vector2(rb.velocity.x * jumpBoost, jumpForce);
            rb.AddForce(rb.mass * force, ForceMode2D.Impulse);
            OnJump?.Invoke();
        }
        
        if(rb.velocity.y < 0.2f && rb.velocity.magnitude > 0.2f)OnFall?.Invoke();
    }
    
    private void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
    }
}
