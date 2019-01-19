/*
 * 测试单例模板
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SingletonTest : Singleton<SingletonTest> {

#if UNITY_EDITOR
    [MenuItem("Tools/Test %q", false, 1)]
    static void MenuClicked()
     {
        var initInstance = SingletonTest.Instance;
        initInstance = SingletonTest.Instance;
     }
#endif
    private SingletonTest()
    {
        Debug.Log("instance");
    }

}
