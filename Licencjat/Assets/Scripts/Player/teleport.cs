using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] private Vector2 tpUp;
    [SerializeField] private Vector2 tpDown;

    [SerializeField] private Vector3 tpCamUp;
    [SerializeField] private Vector3 tpCamDown;

    [SerializeField] private float delay = 0.05f;

    public Camera cam;
    public GameObject camOff;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Teleport Left")
        {
            transform.position = tpUp;
            camOff.SetActive(false);
            cam.transform.position = tpCamUp;
            Invoke("setCamActive", delay);
        }
        else if (hit.collider.name == "Teleport Up Left")
        {
            transform.position = tpDown;
            camOff.SetActive(false);
            cam.transform.position = tpCamDown;
            Invoke("setCamActive", delay);
        }
        
    }

    void setCamActive()
    {
        camOff.SetActive(true);
    }
}
