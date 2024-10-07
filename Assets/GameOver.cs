using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public GameObject panelLoseGame;
    public float delayRestart = 2f;
    public void LoseGame()
    {
        panelLoseGame.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<Jumper>().enabled = false;

        //Invoke(nameof(ReloadScene), delayRestart);
        StartCoroutine(ReloadScene());
    }

    private void Start()
    {
        FindObjectOfType<Jumper>().OnCollision += LoseGame; // am facut subscribe
    }

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(delayRestart);

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
}
