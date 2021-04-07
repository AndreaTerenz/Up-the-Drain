using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = 9.8f;
    public float jumpHeight = 5f;
    public Transform groundCheck;
    public float grndCheckRadius = .4f;
    public LayerMask groundMask;
    
    private CharacterController _controller;
    private float _vSpeed;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 moveDir = (transform.right * x) + (transform.forward * z);
        Vector3 hMov = moveDir * Time.deltaTime * speed;

        _controller.Move(hMov);
        
        if (Physics.CheckSphere(groundCheck.position, grndCheckRadius, groundMask))
        {
            if (_vSpeed <= 0f)
            {
                _vSpeed = -2f;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                _vSpeed = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }

        _vSpeed -= gravity * Time.deltaTime;

        _controller.Move(new Vector3(0f, _vSpeed, 0f) * Time.deltaTime);
    }
}
