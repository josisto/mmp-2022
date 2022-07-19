using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMPro.TMP_Text pilzScoreText;

    int pilzScore = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pilzScoreText.text = pilzScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Add Shroom to counter
    public void AddShroom()
    {
        pilzScore -= 1;
        pilzScoreText.text = pilzScore.ToString();
    }
}
