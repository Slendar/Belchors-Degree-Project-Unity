using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    private int activeScene;
    void Awake()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene == 0 || activeScene == 6)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
    }
}
