using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float momentumDamping = 5f;
    [SerializeField] private float playerSpeed = 10f;
    private CharacterController mycc;

    [SerializeField] private Animator camAnim;
    private bool isMoving;

    public AudioSource running;
        
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;

    void Start()
    {
        mycc = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
        camAnim.SetBool("isMoving", isMoving);
    }

    void GetInput()
    {
        
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
            isMoving = true;
        }
        else
        {
            running.Stop();
            running.Play();
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, Time.deltaTime * momentumDamping);
            isMoving = false;
        }
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        mycc.Move(movementVector * Time.deltaTime);
    }
}
