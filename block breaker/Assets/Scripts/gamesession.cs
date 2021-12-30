using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamesession : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float gamespeed =1f;
    [SerializeField] int pointsperBlock=50;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] int scorecurrent=0;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<gamesession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);       
        }
    }

    private void Start()
    {
        scoreTxt.text = scorecurrent.ToString();
    }
    void Update()
    {
        Time.timeScale = gamespeed;
        scoreTxt.SetText(scorecurrent.ToString());
    }

    public void calcScore()
    {
        scorecurrent = scorecurrent + pointsperBlock;
      //  scoreTxt.text = scorecurrent.ToString();
    }

    public void Resetgame()
    {
        Destroy(gameObject);
    }
}
