using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bestScoreTxt;
    private int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreTxt.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        currentScore++;
        scoreTxt.text = "Score: " + currentScore.ToString();

        if (currentScore >= PlayerPrefs.GetInt("High Score", 0))
        {
            bestScoreTxt.text = "High Score: " + currentScore.ToString();
            PlayerPrefs.SetInt("High Score", currentScore);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IncrementScore();
        collision.GetComponent<AudioSource>().Play();
    }
}
