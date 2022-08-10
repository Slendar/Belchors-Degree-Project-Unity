using UnityEngine;

public class Rules : MonoBehaviour
{
    public GameObject rules;
    public GameObject credits;
    public void showRules()
    {
        rules.SetActive(true);
    }
    public void showCredits()
    {
        credits.SetActive(true);
    }
}
