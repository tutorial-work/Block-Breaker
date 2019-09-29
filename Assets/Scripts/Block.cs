using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Config Params
    [SerializeField] AudioClip breakSound;

    // Cached References
    Level level;
    GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.addBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.removeBlock();
        gameStatus.AddToScore();
    }
}
