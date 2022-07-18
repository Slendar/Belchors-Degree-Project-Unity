using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public Timer time;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
        time.startTimer = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
}
