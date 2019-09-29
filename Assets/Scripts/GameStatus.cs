using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Config Params
    [Range(1, 5)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 1;
    [SerializeField] TextMeshProUGUI scoreTMP;

    // State Variables
    int currentScore = 0;

    private void Start()
    {
        scoreTMP.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreTMP.text = currentScore.ToString();
    }
}
