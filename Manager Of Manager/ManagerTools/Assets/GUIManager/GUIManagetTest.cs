using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManagetTest : MonoBehaviour {

	
	void Start () {

        GUIManager.LoadPanel("FirstPanel",GUIManager.UILayer.Top);
        GUIManager.DeletePanel("FirstPanel", 3f);
        GUIManager.SetResolution(1280, 720, 0);
    }


    void Update () {
		
	}
}
