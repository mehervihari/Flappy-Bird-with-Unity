using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public GameObject PlayButton;
    public GameObject Gameover;
    public TextMeshProUGUI scoreText;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           Pause();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Play();
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        Gameover.SetActive(false);
        PlayButton.SetActive(false);

        Time.timeScale = 1;
        Player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i=0; i<pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Player.enabled = false;
    }

    public void GameOver()
    {
        Gameover.SetActive(true);
        PlayButton.SetActive(true);

        Pause();
        //Debug.Log("game over");
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        //Debug.Log("score inc");
    }
}
