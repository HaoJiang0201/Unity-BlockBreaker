using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    //public GlobalData gdInput;
    //public GlobalStatic gdInput;

    public void LoadNextScene()
    {
        int iCurrentSceneID = SceneManager.GetActiveScene().buildIndex;
        if (iCurrentSceneID == 2)
            iCurrentSceneID = -1;
        SceneManager.LoadScene(iCurrentSceneID+1);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int iSceneID)
    {
        //gdInput.iTest = 2;
        //gdInput.bTest = true;
        //Debug.Log("iTest = " + GlobalStatic.g_iTest1);
        //Debug.Log("bTest = " + GlobalStatic.g_bTest2);
        //GlobalStatic.TestFunction();
        //Debug.Log("iTest = " + GlobalStatic.g_iTest1);
        //Debug.Log("bTest = " + GlobalStatic.g_bTest2);
        SceneManager.LoadScene(iSceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
