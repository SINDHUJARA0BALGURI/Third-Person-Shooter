using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float PlayerMoveSpeed;
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
        var VerticalMovement = Input.GetAxis("Vertical");

        var playerMovement = new Vector3(horizontalMovement, 0, VerticalMovement);
        characterController.SimpleMove(playerMovement* Time.deltaTime*PlayerMoveSpeed);
        anim.SetFloat("Speed", playerMovement.magnitude);

        Quaternion newDirection = Quaternion.LookRotation(playerMovement);
        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime*turnSpeed);

    }
}
