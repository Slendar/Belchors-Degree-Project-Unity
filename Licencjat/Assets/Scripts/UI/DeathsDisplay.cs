using UnityEngine;
using UnityEngine.UI;
public class DeathsDisplay : MonoBehaviour
{
    public Text deathsText;
    public LoadNextLevel next;

    public void Update()
    {
        deathsText.text = next.totalDeaths.ToString();
    }
}
