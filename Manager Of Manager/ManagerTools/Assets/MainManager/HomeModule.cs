using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeModule : MainManager {


    protected override void LaunchInDevelopingMode()
    {
       //开发逻辑
    }

    protected override void LaunchInTestMode()
    {
        // 测试逻辑 
        // 加载资源 
        // 初始化 SDK
        // 点击开始游戏 
        GameModule.LoadModule();

    }

    protected override void LaunchInProductionMode()
    {
        // ⽣生产逻辑 
        // 加载资源 
        // 初始化 SDK 
        // 点击开始游戏 
        GameModule.LoadModule();

    }
}
