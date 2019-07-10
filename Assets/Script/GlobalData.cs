using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {

    public int iTest;
    public bool bTest;

    public void TestFunction()
    {
        iTest = 100;
    }

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
