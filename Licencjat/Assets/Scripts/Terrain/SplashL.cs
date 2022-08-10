using UnityEngine;

public class SplashL : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Lava Splash");

        }
    }
}
