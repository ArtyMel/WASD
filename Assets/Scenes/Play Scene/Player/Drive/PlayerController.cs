using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator; 

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _charapterController;
    void Start()
    {
        _charapterController = GetComponent<CharacterController>();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _charapterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    private void MoveUpdate()
    {
        _moveVector = Vector3.zero;
        var runDerection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDerection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDerection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDerection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDerection = 4;
        }
        animator.SetInteger("Run Drection", runDerection);
    }

    void Update()
    {
        MoveUpdate();
        Jump();
    }

    

    void FixedUpdate()
    {
        _charapterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _charapterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_charapterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}

