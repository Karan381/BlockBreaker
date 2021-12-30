using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour
{
    //config params
    [SerializeField] GameObject blockvfx;
    [SerializeField] AudioClip clip;
   // [SerializeField] int Maxhits;
    [SerializeField] Sprite[] hitblocks;
    
    //caches ref
    level clevel;
    gamesession gameStatus;

    //state variables
    [SerializeField] int timesHit;  //for debug purpose 

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            handlehit();
        }

    }

    private void handlehit()
    {
        int Maxhits = hitblocks.Length + 1;
        timesHit++;
        if (timesHit >= Maxhits)
        {
            DestroyBlock();
        }
        else
        {
            Shownexthitsprite();
        }
    }

    private void Shownexthitsprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitblocks[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitblocks[spriteIndex];
        }
        else {
            Debug.Log("Error Block Sprite Missing" + gameObject.name);
               }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
        clevel.blockdest();
        gameStatus = FindObjectOfType<gamesession>();
        gameStatus.calcScore();
        TriggerSparkles();
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        clevel = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            clevel.countblocks();
        }
    }

    private void  TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockvfx, transform.position, transform.rotation);
        Destroy(sparkles, 2f); 
    }
    

}
