using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float sprintSpeedMult = 2f;
    
    public float gravity = 9.8f;
    public float jumpHeight = 5f;
    
    public Transform groundCheck;
    public float grndCheckRadius = .4f;
    public LayerMask groundMask;
    
    private CharacterController _controller;
    private float _vSpeed;
    private bool _onGround;
    private bool _stopSprintOnLanding;
    private bool _isSprinting;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        _onGround = Physics.CheckSphere(groundCheck.position, grndCheckRadius, groundMask);
        
        MoveVertically();
        MoveHorizontally();
    }

    void MoveHorizontally()
    {
        Sprint();
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = (transform.right * x) + (transform.forward * z);
        Vector3 hMov = moveDir * (Time.deltaTime * speed);

        _controller.Move(hMov);
    }

    void MoveVertically()
    {
        if (_onGround)
        {
            //Debug.Log("on ground");
            _vSpeed = Mathf.Max(0f, _vSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                _vSpeed = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
        else
        {
            //Debug.Log("not on ground");
            _vSpeed -= gravity * Time.deltaTime;
        }

        _controller.Move(new Vector3(0f, _vSpeed, 0f) * Time.deltaTime);
    }

    void Sprint()
    {
        if (!_stopSprintOnLanding)
        {
            if (Input.GetButtonDown("Sprint") && _onGround)
            {
                speed *= sprintSpeedMult;
                _isSprinting = true;
            }

            if (Input.GetButtonUp("Sprint"))
            {
                if (_onGround && _isSprinting)
                {
                    speed /= sprintSpeedMult;
                    _isSprinting = false;
                }
                else if (_isSprinting)
                {
                    _stopSprintOnLanding = true;
                }
            }
        }
        else if (_onGround)
        {
            speed /= sprintSpeedMult;
            _isSprinting = false;
            _stopSprintOnLanding = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("DIO PORCO");
    }
}
