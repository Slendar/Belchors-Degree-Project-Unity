using UnityEngine;
using UnityEngine.UI;
public class TimerDisyplay : MonoBehaviour
{
    public Text timerText;
    public LoadNextLevel next;

    public void Update()
    {
        timerText.text = next.totalMinutes.ToString("00") + ":" + ((int)next.totalSeconds).ToString("00");
    }
}
