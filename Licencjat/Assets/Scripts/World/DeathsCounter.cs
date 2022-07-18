using UnityEngine;
using UnityEngine.UI;

public class DeathsCounter : MonoBehaviour
{

    [System.NonSerialized] public int deaths;
    public Text deathsText;
    // Start is called before the first frame update
    void Start()
    {
        deaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deathsText.text = "Deaths: " + deaths;
    }
}
