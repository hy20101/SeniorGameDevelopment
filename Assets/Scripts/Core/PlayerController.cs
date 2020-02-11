using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float JumpHeight = 2f;
    //public float Gravity = -9.81f;
    //public float GroundDistance = 0.2f;
    bool isGrounded;
    private Vector3 _velocity;
    private CharacterController _controller;

    void Start()
    {
        isGrounded = true;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        movementInput();
        PlayerJump();
    }

    void movementInput()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        float _jump = Input.GetAxis("Jump");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        //transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
        _controller.Move(_movement * Time.deltaTime * movementSpeed);

        //_velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(transform.position.x, JumpHeight, transform.position.z);
            Debug.Log("jump!");
        }
    }
    
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isGrounded = false;
        }
    }

    /*public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    //public Transform _groundChecker;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _isGrounded = false;
        }

        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            _isGrounded = false;
        }
    }*/
}