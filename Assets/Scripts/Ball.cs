using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 2f;

    // Variables
    float launchForce = 8f;

    // state
    Vector2 paddleToBallVector;
    Vector2 ballToPointerVector;
    bool hasStarted = false;

    // Cached component references
    Pointer pointer;
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;

        pointer = FindObjectOfType<Pointer>();
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }
    
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            float currentAngle = pointer.transform.eulerAngles.z;
            float radians = currentAngle * (2 * Mathf.PI / 360);
            float xForce = launchForce * Mathf.Sin(radians);
            float yForce = launchForce * Mathf.Cos(radians);
            Debug.Log((xForce, yForce));
            GetComponent<Rigidbody2D>().velocity = new Vector2(-xForce, yForce);
            hasStarted = true;
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    public bool HasStarted()
    {
        return hasStarted;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        //float velocityX = UnityEngine.Random.Range(0f, randomFactor);
        //float velocityY = UnityEngine.Random.Range(0f, randomFactor);
        //Vector2 velocityTweak = new Vector2(velocityX, velocityY);

        // Otherwise turn on this code
        Vector2 velocityTweak = new Vector2(0, 0);
        if (UnityEngine.Random.Range(0, 10) == 0)
        {
            if(UnityEngine.Random.Range(0, 2) == 0)
            {
                velocityTweak.x += 5f;
            }
            else
            {
                velocityTweak.x += -5f;
            }
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                velocityTweak.y += randomFactor;
            }
            else
            {
                velocityTweak.y += -randomFactor;
            }
        }

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
