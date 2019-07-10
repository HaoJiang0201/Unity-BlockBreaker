using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // Config Params
    [SerializeField] AudioClip breakSounds;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int MaxHit;
    [SerializeField] Sprite[] hitSprites;

    // Cached Reference
    Level level;

    // Status Variables
    GameStatus status;
    int iCurHit;
    //int iPicIndex;
    //float time;
    
    private void Start()
    {
        // Looking for a particular type of thing that is "level" in current Scene.
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            iCurHit = 0;
            level.CountBlocks();
        }
        status = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        iCurHit++;
        int iMaxHit = hitSprites.Length + 1;
        if (iCurHit >= iMaxHit)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHiSprite();
        }
    }

    private void ShowNextHiSprite()
    {
        int spriteIndex = iCurHit-1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array.");
        }
    }

    private void DestroyBlock()
    {
        status.AddToScore();    // 加分

        PlayBlockDestroySFX();  // 播放音效 

        TriggerSparklesVFX();   // 播放粉碎特效

        Destroy(gameObject);    // 销毁砖块对象

        level.BlockDestroyed(); // 计算剩余砖块 
    }

    private void PlayBlockDestroySFX()
    {
        UnityEngine.Random.Range(1.0f, 3.0f);
        AudioSource.PlayClipAtPoint(breakSounds, Camera.main.transform.position, 1.0f);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);  // 延迟销毁该特效对象
    }

}
