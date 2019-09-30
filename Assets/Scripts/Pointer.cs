using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    // Variables
    Vector2 ballToPointerVector;

    // Cached References
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();

        ballToPointerVector = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ball.HasStarted())
        {
            RotatePointer();
            LockToBall();
        }
        else
        {
            Destroy(gameObject);
        } 
    }

    private void RotatePointer()
    {
        // rotate pointer
        float addedRotation = Input.mouseScrollDelta.y;
        float currentAngle = transform.rotation.eulerAngles.z;
        if (currentAngle > 180)
        {
            currentAngle -= 360;
        }

        bool check1 = addedRotation < 0 && currentAngle > -45;
        bool check2 = addedRotation > 0 && currentAngle < 45;
        if (check1 || check2)
        {
            transform.Rotate(0, 0, Input.mouseScrollDelta.y);
        }

        // recreate ballToPointerVector
        float radians = currentAngle * (2 * Mathf.PI / 360);
        ballToPointerVector.x = -1 * (ballToPointerVector.magnitude * Mathf.Sin(radians));
        ballToPointerVector.y = ballToPointerVector.magnitude * Mathf.Cos(radians);

    }

    private void LockToBall()
    {
        Vector2 ballPosition = new Vector2(ball.transform.position.x, ball.transform.position.y);
        transform.position = ballPosition + ballToPointerVector;
    }
}
