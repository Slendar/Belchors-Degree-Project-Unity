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

    void Start()
    {
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
    void Update()
    {
        if (canDoAction)
        {
            moveDirection = new Vector3(Input.GetAxis(controls), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (controller.isGrounded)
            {
                // we are grounded so forceY is 0
                forceY = 0;
                // invertGrav is also reset based on the gravity
                invertGrav = gravity * airTime;
                if (Input.GetButtonDown(jumpControl))
                {
                    // we jump 
                    forceY = jumpSpeed;
                }
            }
            // We are now jumping since forceY is not 0
            // we add invertGrav to our jumpForce and invertGrav is also
            // decreased so that we get a curvy jump
            if (Input.GetButton(jumpControl) && forceY != 0)
            {
                invertGrav -= Time.deltaTime;
                forceY += invertGrav * Time.deltaTime;
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
