using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int points = 10;
    public int hitPoints = 1;
    public Sprite[] damageSprites;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (damageSprites != null && damageSprites.Length > 0)
        {
            UpdateBlockSprite();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            ScoreManager.Instance.AddScore(points);
            GameController gameController = FindObjectOfType<GameController>();

            if (gameController != null)
            {
                gameController.BrickDestroyed();
            }

            Destroy(gameObject);
        }
        else
        {
            if (damageSprites != null && damageSprites.Length > 0)
            {
                UpdateBlockSprite();  // Cambia el sprite solo si hay sprites en damageSprites
            }
        }
    }

    void UpdateBlockSprite()
    {
        // Cambia el sprite en funci�n de la vida actual (hitPoints)
        if (damageSprites != null && damageSprites.Length > 0) {

            int spriteIndex = Mathf.Clamp(hitPoints - 1, 0, damageSprites.Length - 1);
            spriteRenderer.sprite = damageSprites[spriteIndex];
        }
    }
}