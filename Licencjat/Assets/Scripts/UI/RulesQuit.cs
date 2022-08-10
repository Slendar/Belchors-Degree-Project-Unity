using UnityEngine;

public class RulesQuit : MonoBehaviour
{
    public GameObject options;
    public void quitRules()
    {
        options.SetActive(false);
    }
}
