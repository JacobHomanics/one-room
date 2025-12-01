using JacobHomanics.Timer;
using TMPro;
using UnityEngine;

public class PlayerPrefSaver : MonoBehaviour
{
    public Timer timer;
    public TMP_Text text;

    void Start()
    {
        if (text)
            Load();
    }
    public void Load()
    {
        text.text = PlayerPrefs.GetInt("HighScore").ToString() + " seconds";
    }

    public void Save()
    {
        if (PlayerPrefs.GetInt("HighScore") < (int)timer.ElapsedTime)
            PlayerPrefs.SetInt("HighScore", (int)timer.ElapsedTime);
    }
}
