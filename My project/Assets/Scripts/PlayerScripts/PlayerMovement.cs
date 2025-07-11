using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController PlayerController;
    private Vector3 JumpPower;
    private Rigidbody rb;
    private float moveSpeed = 10;
    private float attackSpeed;
    private float strafeSpeed;
    private float runStamia = 20;
    private float attackStamia = 10;
    private float gravity = -9.81f;
    private bool groundedPlayer;
    private Vector3 move;
    private float jumpHeight = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerController = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = PlayerController.isGrounded;
        if (groundedPlayer && JumpPower.y > 0)
        {
            JumpPower.y = 0f;
        }
    }
    public void PlayerMove()
    {
         move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, moveSpeed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            JumpPower.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        JumpPower.y += gravity * Time.deltaTime;

        Vector3 finalMove = (move * moveSpeed) + (JumpPower.y * Vector3.up);
        PlayerController.Move(finalMove * Time.deltaTime);
    }
}
