﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;

    //scoring
    private int score;
    public TextMeshProUGUI scoreText;

    //Game over
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    //Restart
    public Button restartButton;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

        isGameActive = false;

        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        //Game Over
        isGameActive = true;

        StartCoroutine(SpawnTarget());

        //Score count
        score = 0;
        UpdateScore(0);

        spawnRate = spawnRate / difficulty;

        titleScreen.gameObject.SetActive(false);
    }
}