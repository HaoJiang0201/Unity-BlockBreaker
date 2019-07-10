using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // Parameters
    [SerializeField] int iBlocksLeft;
    [SerializeField] public int iLevelID;

    // Catched Reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks () {
        iBlocksLeft ++;
	}

    public void BlockDestroyed()
    {
        iBlocksLeft--;
        if (iBlocksLeft <= 0)
        {
            FindObjectOfType<GameStatus>().GetComponent<AudioSource>().Play();
            sceneLoader.LoadNextScene();
        }
    }
	
}
