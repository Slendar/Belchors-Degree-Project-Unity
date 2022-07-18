using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] public GameObject helpWindow;
    [SerializeField] public GameObject helpShortcut;
    public GameObject levelComplete;
    private bool isActive;

    public void Start()
    {
        isActive = true;
        helpWindow.SetActive(isActive);
        helpShortcut.SetActive(!isActive);
        Invoke("setDisactive", 5f);
    }

    public void Update()
    {
        if(Input.GetButtonDown("H"))
        {
            isActive = !isActive;
            helpWindow.SetActive(isActive);
            helpShortcut.SetActive(!isActive);
        }
        if (true)
        {

        }
        
    }

    private void setDisactive()
    {
        helpWindow.SetActive(!isActive);
        helpShortcut.SetActive(isActive);
    }


}
