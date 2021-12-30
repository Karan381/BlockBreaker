using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level : MonoBehaviour
{
    [SerializeField] int breakableblocks;
    
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void countblocks()
    {
        breakableblocks++;
    }

    public void blockdest()
    {
        breakableblocks--;
        if(breakableblocks<=0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
