using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text startGameText;

    int timeCounter = 0;
    int points;
    public bool gameOver = false;
    bool timeStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(PassTime());
        timeText.text = "Time" + timeCounter.ToString();
        pointsText.text = "Points" + points.ToString();
        gameOverText.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!timeStarted)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timeStarted = true;
                    Time.timeScale = 1;
                    startGameText.gameObject.SetActive(false);
                }
            }
            if (gameOver)
            {
                Time.timeScale= 1;
                gameOverText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You died! Press Space to continue";
        gameOver= true;
    }

    public void AddPoints(int pointsAdded)
    {
        points += pointsAdded;
        pointsText.text = "Points" + points.ToString();
    }

    IEnumerator PassTime()
    {
        while(!gameOver)
        {
            timeCounter++;
            timeText.text = "Time" + timeCounter.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
