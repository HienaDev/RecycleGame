using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score = 0;
    public int gameLimit;
    private int currentIdleTrash;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        setScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLimit < currentIdleTrash) {
            endGame();
        }
    }

    public void increaseIdleStrash() {
        currentIdleTrash++;
    }

    public void reduceIdleStrash() {
        currentIdleTrash--;
    }
    public void ScoreIncrease() {
        score += 1;
        setScoreText(score);
    }

    public void endGame() {
        SceneManager.LoadScene("MenuD&D", LoadSceneMode.Single);
    }

    private void setScoreText(int score) {
        scoreText.text = score.ToString();
    }
}
