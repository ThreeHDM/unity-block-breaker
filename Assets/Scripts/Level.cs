using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Parameters
    //We create a variable to keep track of the amount of blocks. We SerializeField so we can see it in the inspector for debugging purposes
    [SerializeField] int breakableBlocks;

    //cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    //We create a public method to count the breakable blocks. Each time is called we add 1 to the total number of breakable blocks
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    //We decrease the number of blocks each time one is broken
    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
