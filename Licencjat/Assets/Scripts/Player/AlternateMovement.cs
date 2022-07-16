using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 20.0F;
    public float gravityForce = 3.0f;
    public float airTime = 2f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float forceY = 0;
    private float invertGrav;

    public bool canDoAction = true;

    void Start()
    {
        // invertGrav is set greater than gravity so that our guy jumps
        invertGrav = gravity * airTime;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (canDoAction)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (controller.isGrounded)
            {
                // we are grounded so forceY is 0
                forceY = 0;
                // invertGrav is also reset based on the gravity
                invertGrav = gravity * airTime;
                if (Input.GetButtonDown("Jump"))
                {
                    // we jump 
                    forceY = jumpSpeed;
                    Debug.Log(transform.position.x);
                }
            }
            // We are now jumping since forceY is not 0
            // we add invertGrav to our jumpForce and invertGrav is also
            // decreased so that we get a curvy jump
            if (Input.GetButton("Jump") && forceY != 0)
            {
                invertGrav -= Time.deltaTime;
                forceY += invertGrav * Time.deltaTime;
                Debug.Log(transform.position.x);
            }
            // Here we apply the gravity
            forceY -= gravity * Time.deltaTime * gravityForce;
            moveDirection.y = forceY;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

        /////////////////////////////////////////////////////////////////
        public float pushPower = 2.0F;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
