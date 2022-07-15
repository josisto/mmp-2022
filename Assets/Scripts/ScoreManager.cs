using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMPro.TMP_Text pilzScoreText;
    public TMPro.TMP_Text pilzTimer;

    int pilzScore = 0;

    private bool TimerOn = false;
    private float TimeLeft;

    private string CurrentShroom = "";

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pilzScoreText.text = "Score: " + pilzScore.ToString();
        pilzTimer.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            } 
            else
            {
                pilzTimer.text = "";
                TimerOn = false;
                TimeLeft = 0;
                RemoveShroomImpact(CurrentShroom);
            }
        }
    }

    // Add Shroom to counter
    public void AddShroom()
    {
        pilzScore += 1;
        pilzScoreText.text = "Score: " + pilzScore.ToString();
    }

    public void ActivateShroomTimer(float seconds, string shroomType)
    {
        TimeLeft = seconds;
        TimerOn = true;
        CurrentShroom = shroomType;
    }

    void UpdateTimer(float currentTime)
    {
        float seconds = Mathf.FloorToInt(currentTime);
        pilzTimer.text = CurrentShroom + ": " + seconds.ToString();
    }

    public void RemoveShroomImpact(string Shroom)
    {
        CurrentShroom = "";
    }
}
