using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidth;
        mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, 0, screenWidth);

        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        transform.position = paddlePosition;
    }
}
