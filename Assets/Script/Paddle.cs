using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour {

    [SerializeField] float fScreenWidthInUnits = 16f;  //Camera Half Height Unity Unity is 6, so the width is 8 (4:3)
    [SerializeField] float fMinX = 1f, fMaxX = 15f;

    // cached references
    GameStatus theGameStatus;
    Ball theBall;

	// Use this for initialization
	void Start () {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector2 v2PaddlePos = new Vector2(transform.position.x, transform.position.y);
        v2PaddlePos.x = Mathf.Clamp(GetXPos(), fMinX, fMaxX);
        transform.position = v2PaddlePos;
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled()/* || FindObjectOfType<Level>().iLevelID == 2*/)
        {
            return theBall.transform.position.x;
        }
        else
        {
            return  (Input.mousePosition.x / Screen.width) * fScreenWidthInUnits;
            //float fCurrentMousePosX = ((Input.mousePosition.x - Screen.width/2)/Screen.width) * fScreenWidthInUnits;
        }
    }

}
