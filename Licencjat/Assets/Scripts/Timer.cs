using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool startTimer;
    public AlternateMovement playerMovement;

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
        once = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!once)
        {
            if (Input.GetAxisRaw(playerMovement.controls) == -1 || Input.GetAxisRaw(playerMovement.controls) == 1)
            {
                startTimer = true;
                once = true;
            }
        }
        if (startTimer)
        {
            updateTimerUI();
        }
    }
    public void updateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00");
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}