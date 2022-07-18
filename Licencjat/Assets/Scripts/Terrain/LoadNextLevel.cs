using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadNextLevel : MonoBehaviour
{
    public Timer time;
    public DeathsCounter deaths;
    public GameObject completeLevelUI;
    [System.NonSerialized] public int totalDeaths;
    [System.NonSerialized] public int totalMinutes;
    [System.NonSerialized] public float totalSeconds;

    private string txtDocumentName = Application.streamingAssetsPath + "/Dla_Karola/" + "Wyslac" + ".txt";

    private void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Dla_Karola/");

        createTextFile();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
        time.startTimer = false;
        totalDeaths = deaths.deaths;
        totalMinutes = time.minuteCount;
        totalSeconds = (int)time.secondsCount;
        completeLevelUI.SetActive(true);
        writeTextFile();
        //loads ne level
    }

    public void createTextFile()
    {
        

        if (!File.Exists(txtDocumentName))
        {
            File.WriteAllText(txtDocumentName, "");
        }
    }

    public void writeTextFile()
    {
        File.AppendAllText(txtDocumentName, SceneManager.GetActiveScene().name + " Deaths: " + totalDeaths.ToString() + " Time: " + totalMinutes.ToString("00") + ":" + ((int)totalSeconds).ToString("00") + "\n");
    }
    
}
