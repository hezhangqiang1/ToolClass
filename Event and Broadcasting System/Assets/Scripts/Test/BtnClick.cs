/*
 * 按钮的监听方法 点击按钮的时候广播show方法
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour {

	
	void Awake () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(()=>
          EventCenter.Broadcast(EventType.ShowText,"你好，世界")
            );
	}
	
}
