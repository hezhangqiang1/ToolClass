/*
 * MainManager 入口管理器
 * 管理多个入口 
 * 负责游戏的启动流程 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnvironmentMode
{
    Developing, //开发中版本
    Test,       //测试版本
    Production  //发布版本
}

public abstract class MainManager : MonoBehaviour {

    public EnvironmentMode Mode;
    private  static EnvironmentMode mSharedMode;
    private static bool mModeSetted = false;
	
	void Start () {
        if (!mModeSetted)
        {
            mSharedMode = Mode;
            mModeSetted = true;
        }
        switch (mSharedMode)
        {
            case EnvironmentMode.Developing:
                LaunchInDevelopingMode();
                break;
            case EnvironmentMode.Test:
                LaunchInTestMode();
                break;
            case EnvironmentMode.Production:
                LaunchInProductionMode();
                break;

        }

	}
    protected abstract void LaunchInDevelopingMode();
    protected abstract void LaunchInProductionMode();
    protected abstract void LaunchInTestMode();


}
