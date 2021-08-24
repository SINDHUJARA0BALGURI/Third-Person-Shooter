using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float PlayerMoveSpeed;
    public float playerBackwardSpeed;
    Animator anim;
    [SerializeField]
    private float turnSpeed=10f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var VerticalMovement = Input.GetAxis("Mouse X");

        var playerMovement = new Vector3(horizontalMovement, 0, VerticalMovement);
       
        anim.SetFloat("Speed", VerticalMovement);
        transform.Rotate(Vector3.up, horizontalMovement * turnSpeed * Time.deltaTime);
        if (VerticalMovement != 0)
        {
            float moveSpeed = (VerticalMovement > 0) ? PlayerMoveSpeed : playerBackwardSpeed;

            characterController.SimpleMove(playerMovement* Time.deltaTime*PlayerMoveSpeed);
        }

        // Quaternion newDirection = Quaternion.LookRotation(playerMovement);
        //  transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime*turnSpeed);

    }
}
