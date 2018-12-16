/*
 * 视图层：显示数量，通过订阅数据层消息
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {

    public Text NumText;
	

    void Start()
    {
        MassageDispatcher.Register("Change", ChangeNum);
    }
	
	public  void ChangeNum(object data)
    {
        NumText.text = data.ToString();
    }
    void OnDestroy()
    {
        MassageDispatcher.UnRegister("Change", ChangeNum);
    }
}
