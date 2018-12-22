/*
 * 游戏模块脚本
 * 作为游戏模块的入口
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModule : MainManager {
    

    public static void LoadModule()
    {
        SceneManager.LoadScene("Game");
    }

    protected override void LaunchInDevelopingMode()
    {
        //开发逻辑
        Debug.Log("开发逻辑");
    }

    protected override void LaunchInTestMode()
    {
        //测试逻辑
        Debug.Log("测试逻辑");
    }

    protected override void LaunchInProductionMode()
    {
        //生产逻辑
        Debug.Log("生产逻辑");
    }

}
