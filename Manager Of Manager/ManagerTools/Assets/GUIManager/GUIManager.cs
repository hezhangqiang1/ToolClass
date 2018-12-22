/*
 * UI管理器 
 * 动态加载和卸载UIPanel 
 * 管理UI的层级
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    /// <summary>
    /// UI层级
    /// </summary>
    public  enum UILayer
    {
        Bottom,  //底层
        Middle,  //中层
        Top      //顶层
    }
    private static GameObject mPrivateUIRoot;
    /// <summary>
    /// 构造方法 把UIRoot 这个定义好的Canvas实例化出来
    /// </summary>
    public static GameObject UIRoot
    {
        get
        {
            if (mPrivateUIRoot == null)
            {
                var UIRootPrefab = Resources.Load<GameObject>("UIRoot");
                mPrivateUIRoot = GameObject.Instantiate(UIRootPrefab);
                mPrivateUIRoot.name = "UIRoot";
            }
            return mPrivateUIRoot;
        }
    }
    private static Dictionary<string, GameObject> mPanelDict = new Dictionary<string, GameObject>();
    /// <summary>
    /// 删除UI界面
    /// </summary>
    /// <param name="panelName">UI界面名字</param>
    /// <param name="deleteTime">多久后删除</param>
    public static void DeletePanel(string panelName,float deleteTime)
    {
        if (mPanelDict.ContainsKey(panelName))
        {
            Destroy(mPanelDict[panelName], deleteTime);
        }
    }

    /// <summary>
    /// 动态加载UI界面
    /// </summary>
    /// <param name="PanelName">UI界面名字</param>
    /// <returns></returns>
	public static GameObject LoadPanel(string PanelName,UILayer layer)
    {
        var PanelPrefab = Resources.Load<GameObject>(PanelName);
        var PanelObject = GameObject.Instantiate(PanelPrefab);

       

        switch (layer)
        {
            case UILayer.Bottom:
                PanelObject.transform.SetParent(UIRoot.transform.Find("Bottom"));
                break;
            case UILayer.Middle:
                PanelObject.transform.SetParent(UIRoot.transform.Find("Middle"));
                break;
            case UILayer.Top:
                PanelObject.transform.SetParent(UIRoot.transform.Find("Top"));
                break;

        }
        
        var PanelRectTrans = PanelObject.transform as RectTransform;
        PanelRectTrans.offsetMin = Vector2.zero;
        PanelRectTrans.offsetMax = Vector2.zero;
        PanelRectTrans.anchoredPosition3D = Vector3.zero;
        PanelRectTrans.anchorMin = Vector2.zero;
        PanelRectTrans.anchorMax = Vector2.one;

        PanelObject.name = PanelName;
        mPanelDict.Add(PanelObject.name, PanelObject);
        return PanelObject;
    }
    /// <summary>
    /// 设置屏幕适配
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="matchWidthOrHeight"></param>
    public static void SetResolution(float width, float height, float matchWidthOrHeight)
    {   var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(width, height);
        canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
    }

}
