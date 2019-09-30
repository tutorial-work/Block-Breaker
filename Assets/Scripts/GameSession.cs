using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Config Params
    [Range(1, 20)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 1;
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] bool isAutoPlayEnabled;

    // State Variables
    int currentScore = 0;

    private void Awake()
    {
        //gameSpeed
        //pointsPerBlock
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            DestroyGameSession();
            GameSession gameSession = FindObjectOfType<GameSession>();
            gameSession.gameSpeed = gameSpeed;
            gameSession.pointsPerBlock = pointsPerBlock;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        

    }

    private void Start()
    {
        scoreTMP.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreTMP.text = currentScore.ToString();
    }

    public void DestroyGameSession()
    {
        Destroy(gameObject);
    }
}
