using UnityEngine;

public class Splash : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Water Splash");

        }
    }
}
