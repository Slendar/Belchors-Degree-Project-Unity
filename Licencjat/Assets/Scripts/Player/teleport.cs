using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector2 tpUp;
    [SerializeField] private Vector2 tpDown;
    [SerializeField] private Vector2 tpRDown;

    [SerializeField] private float delay = 0.05f;

    public Camera cam;
    public GameObject camOff;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Teleport Left")
        {
            tpPlayer(tpUp);
        }
        else if (hit.collider.name == "Teleport Up Left")
        {
            tpPlayer(tpDown);
        }
        else if (hit.collider.name == "Teleport Up Right")
        {
            tpPlayer(tpRDown);
        }
    }

    void setCamActive()
    {
        camOff.SetActive(true);
    }

    void tpPlayer(Vector2 tp)
    {
        transform.position = tp;
        camOff.SetActive(false);
        Invoke("setCamActive", delay);
    }
}
