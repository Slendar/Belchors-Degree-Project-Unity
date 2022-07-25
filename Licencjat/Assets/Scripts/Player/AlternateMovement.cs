using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool canDoAction = false;

    private int activeScene;
    [System.NonSerialized] public string controls;
    private string jumpControl;

    public Animator animator;

    void Start()
    {
        animator.SetBool("WasMovingRight", true);
        // invertGrav is set greater than gravity so that our guy jumps
        invertGrav = gravity * airTime;
        controller = GetComponent<CharacterController>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
        switch (activeScene)
        {
            case 1:
                controls = "Horizontal";
                jumpControl = "Jump";
                break;
            case 2:
                controls = "Horizontal JL";
                jumpControl = "Jump I";
                break;
            case 3:
                controls = "Horizontal EQ";
                jumpControl = "Jump S";
                break;
            case 4:
                controls = "Horizontal IK";
                jumpControl = "Jump J";
                break;
            case 5:
                controls = "Horizontal ERShift";
                jumpControl = "Jump LCtrl";
                break;

        }
    }
    void FixedUpdate()
    {
        if (canDoAction)
        {
            moveDirection = new Vector3(Input.GetAxis(controls), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (moveDirection.x > 0)
            {
                animator.SetBool("WasMovingLeft", false);
                animator.SetBool("IsMovingRight", true);
                animator.SetBool("WasMovingRight", true);
            }
            else if (moveDirection.x <0)
            {
                animator.SetBool("WasMovingRight", false);
                animator.SetBool("IsMovingLeft", true);
                animator.SetBool("WasMovingLeft", true);
            }
            else
            {
                animator.SetBool("IsMovingLeft", false);
                animator.SetBool("IsMovingRight", false);
            }
            if (controller.isGrounded)
            {
                animator.SetBool("IsFreeFalling", false);
                animator.SetBool("IsFalling", false);
                animator.SetBool("IsJumping", false);
                animator.SetBool("Jumped", false);
                // we are grounded so forceY is 0
                forceY = 0;
                // invertGrav is also reset based on the gravity
                invertGrav = gravity * airTime;
                if (Input.GetButtonDown(jumpControl))
                {
                    // we jump 
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("Jumped", true);
                    forceY = jumpSpeed;
                }
            }
            // We are now jumping since forceY is not 0
            // we add invertGrav to our jumpForce and invertGrav is also
            // decreased so that we get a curvy jump
            if (Input.GetButton(jumpControl) && forceY != 0)
            {
                //animator.SetBool("IsJumping", true);
                invertGrav -= Time.deltaTime;
                forceY += invertGrav * Time.deltaTime;
            }
            // Here we apply the gravity
            forceY -= gravity * Time.deltaTime * gravityForce;
            moveDirection.y = forceY;
            controller.Move(moveDirection * Time.deltaTime);
            if(!controller.isGrounded && animator.GetBool("IsJumping"))
            {
                Invoke("yes", 0.1f);
            }
            else if (!controller.isGrounded && !animator.GetBool("Jumped"))
            {
                animator.SetBool("IsFreeFalling", true);
            }

            
            
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

    void yes()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", true);
    }
}
