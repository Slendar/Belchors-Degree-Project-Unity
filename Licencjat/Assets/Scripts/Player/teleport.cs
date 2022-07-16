using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] private Vector2 tpUp;
    [SerializeField] private Vector2 tpDown;

    public bool triggerUp = false;
    public bool triggerDown = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Teleport Left")
        {
            transform.position = tpUp;
            triggerUp = true;
           // Wait(5);

        }
        else if (hit.collider.name == "Teleport Up Left")
        {
            transform.position = tpDown;
            triggerDown = true;
           // Wait(5);
        }
        
    }
    public void Wait(int time)
    {
        new WaitForSeconds(time);
        triggerUp = false;
        triggerDown = false;
    }
}
