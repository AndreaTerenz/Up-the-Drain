using System;
using New_Player_Controller.Player_FSM;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basics")]
    public float normalSpeed = 12f;
    public float gravity = 9.8f;
    public float jumpHeight = 5f;
    
    [Header("Sprinting")]
    public float sprintSpeedMult = 2f;

    [Header("Crouching")]
    public float crouchFactor = .5f;
    public float crouchSpeedMult = .75f;
    
    [Header("Ground checking")]
    public Transform groundCheck;
    public float grndCheckRadius = .4f;
    public LayerMask groundMask;
    
    private CharacterController _controller;
    
    private PlayerState _state;
    public PlayerState State
    {
        get => _state;
        set
        {
            if (value != null)
            {
                _state = value;
                _state.Start(this);
            }
        }
    }
    
    [HideInInspector]
    public float vertSpeed;
    
    private float _hSpeed;
    private float _hSpeedSprint;
    private float _hSpeedCrouch;
    private bool isSprinting
    {
        get => (Math.Abs(_hSpeed - _hSpeedSprint) < Constants.FloatingPointTolerance);
    }
    
    private float _yScale;
    private float _yScaleCrouch;
    private bool isCrouching
    {
        get => (Math.Abs(_hSpeed - _hSpeedCrouch) < Constants.FloatingPointTolerance);
    }
    
    private bool _onGround;
    private bool _sprintSpeedOnLanding;
    private bool _crouchSpeedOnLanding;
    
    void Start()
    {
        State = new StandardState();
        
        _controller = GetComponent<CharacterController>();

        _hSpeed = normalSpeed;
        _hSpeedCrouch = normalSpeed * crouchSpeedMult;
        _hSpeedSprint = normalSpeed * sprintSpeedMult;
        _yScale = transform.localScale.y;
        _yScaleCrouch = _yScale * crouchFactor;
    }
    
    void Update()
    {
        _onGround = Physics.CheckSphere(groundCheck.position, grndCheckRadius, groundMask);
        State = State.Update(this, _onGround);
/*
        vertSpeed = State.verticalSpeed;
        _hSpeed = State.horizontalSpeed;
        transform.localScale = State.scale;
         
        _controller.Move(new Vector3(0f, vertSpeed, 0f) * Time.deltaTime);
        
        float x = Mathf.Round(Input.GetAxis("Horizontal"));
        float z = Mathf.Round(Input.GetAxis("Vertical"));

        Debug.Log(x + " " + z);
        
        Vector3 moveDir = (transform.right * x) + (transform.forward * z);
        Vector3 hMov = moveDir.normalized * (Time.deltaTime * _hSpeed);

        _controller.Move(hMov);
        */
        
        MoveVertically();
        MoveHorizontally();
         
    }

    void MoveHorizontally()
    {
        Sprint();
        Crouch();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = (transform.right * x) + (transform.forward * z);
        Vector3 hMov = moveDir.normalized * (Time.deltaTime * _hSpeed);

        _controller.Move(hMov);
    }

    public float GetJumpSpeed()
    {
        return Mathf.Sqrt(jumpHeight * 2f * gravity);
    }

    void MoveVertically()
    {
        if (_onGround)
        {
            //Debug.Log("on ground");
            vertSpeed = Mathf.Max(0f, vertSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
        else
        {
            //Debug.Log("not on ground");
            vertSpeed -= gravity * Time.deltaTime;
        }

        _controller.Move(new Vector3(0f, vertSpeed, 0f) * Time.deltaTime);
    }

    void Crouch()
    {
        if (!isSprinting || _sprintSpeedOnLanding)
        {
            Vector3 newScale = transform.localScale;
            
            if (_crouchSpeedOnLanding && _onGround)
            {
                _hSpeed = _hSpeedCrouch;
                _crouchSpeedOnLanding = false;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                Debug.Log("crouched");
                newScale.y = _yScaleCrouch;
                
                if (_onGround)
                {
                    _hSpeed = _hSpeedCrouch;
                }
                else
                {
                    _crouchSpeedOnLanding = true;
                }
            }

            if (Input.GetButtonUp("Crouch"))
            {
                Debug.Log("stopped crouching");
                newScale.y = _yScale;
                
                if (_onGround)
                {
                    _hSpeed = normalSpeed;
                }
            }

            transform.localScale = newScale;
        }
    }
    
    void Sprint()
    {
        if (!isCrouching || _sprintSpeedOnLanding)
        {
            if (!_sprintSpeedOnLanding)
            {
                if (Input.GetButtonDown("Sprint") && _onGround)
                {
                    _hSpeed = _hSpeedSprint;
                }

                if (Input.GetButtonUp("Sprint") && isSprinting)
                {
                    if (_onGround)
                    {
                        _hSpeed = normalSpeed;
                    }
                    else
                    {
                        _sprintSpeedOnLanding = true;
                    }
                }
            }
            else if (_onGround)
            {
                _hSpeed = normalSpeed;
                _sprintSpeedOnLanding = false;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("DIO PORCO");
    }
}
