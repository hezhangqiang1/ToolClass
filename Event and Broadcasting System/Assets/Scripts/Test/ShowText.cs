/*
 * 给Text注册事件监听与移除事件监听
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour {

    private void Awake()
    {
        gameObject.SetActive(false);
        EventCenter.AddListener<string>(EventType.ShowText, Show);
    }
	private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(EventType.ShowText, Show);
    }
	private void Show(string str)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Text>().text = str;
    }
}
