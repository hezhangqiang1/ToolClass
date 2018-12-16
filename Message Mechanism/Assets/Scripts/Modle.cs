/*
 * 数据层：存储数据
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modle : MonoBehaviour {

    private int mNum;

    public int Num
    {
        get { return mNum; }
        set { mNum = value; }
    }

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Num++;
            MassageDispatcher.Send("Change", Num.ToString());
        }
	}
}
