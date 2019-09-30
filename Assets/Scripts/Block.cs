using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Config Params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached References
    Level level;
    GameSession gameSession;

    // State Variables
    int timesHit = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            gameSession = FindObjectOfType<GameSession>();
            level.addBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                Destroy(gameObject);
                level.removeBreakableBlock();
                gameSession.AddToScore();
                TriggerSparklesVFX();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + " is missing sprite from hitSprites[]");
        }
        
    }

    private void TriggerSparklesVFX()
    {
        Vector3 sparklesPosition = transform.position;
        sparklesPosition.z = -1;
        GameObject sparkles = Instantiate(blockSparklesVFX, sparklesPosition, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
