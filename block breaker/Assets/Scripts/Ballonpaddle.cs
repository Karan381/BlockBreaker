using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballonpaddle : MonoBehaviour
{
    //config para
    bool hasstarted = false;
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] soundArray;
    [SerializeField] float randompush = 1f;

    //cached ref
    AudioSource myAudioSource;
    Rigidbody2D myrigidbody2d;

    // Start is called before the first frame update

    Vector2 paddleToBallVector;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasstarted)
        {
            sticktopaddle();
            launchballonclick();
        }
    }

    private void launchballonclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasstarted = true;
            myrigidbody2d.velocity = new Vector2(xPush,yPush);
        }
    }

    private void sticktopaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            
        Vector2 velocityrandom = new Vector2(UnityEngine.Random.Range(-1f, randompush),UnityEngine.Random.Range(-1f, randompush));
        
        if (hasstarted)
        {
            AudioClip clip = soundArray[UnityEngine.Random.Range(0, soundArray.Length-1)];
            myAudioSource.PlayOneShot(clip);
            myrigidbody2d.velocity += velocityrandom;
        }

    }
}

