using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Params
    [SerializeField] float screenWidth = 16f;

    // Cached References
    GameSession gameSession;
    Ball ball;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 paddlePosition = new Vector2(GetXPosition(), transform.position.y);
        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if (gameSession.IsAutoPlayEnabled() && ball.HasStarted())
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidth;
            mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, 0, screenWidth);
            return mousePositionInUnits;
        }
    }
}
