using UnityEngine;

public class RulesQuit : MonoBehaviour
{
    public GameObject rules;
    public void quitRules()
    {
        rules.SetActive(false);
    }
}
