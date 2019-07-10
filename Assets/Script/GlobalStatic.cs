using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatic : MonoBehaviour {
    static public int g_iTest1 = 0;
    static public bool g_bTest2 = false;

    static public void TestFunction()
    {
        g_iTest1 = 1;
        g_bTest2 = true;
    }
}
