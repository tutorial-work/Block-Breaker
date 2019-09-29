using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{ 
    // private variables
    int breakableBlockCount = 0;

    // Cached References
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void addBlock()
    {
        breakableBlockCount++;
    }

    public void removeBlock()
    {
        breakableBlockCount--;
        if (breakableBlockCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
