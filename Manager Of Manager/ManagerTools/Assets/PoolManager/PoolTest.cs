using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolTest : MonoBehaviour {

    private class Fish { }
    
    void Start () {
        var fishPool = new SimpleObjectPool<Fish>(() => new Fish(), null, 100);
        Debug.LogFormat("fishPool.CurCount:{0}", fishPool.CurCount);
        var fishOne = fishPool.Allocate();
        Debug.LogFormat("fishPool.CurCount:{0}", fishPool.CurCount);
        fishPool.Recycle(fishOne);
        Debug.LogFormat("fishPool.CurCount:{0}", fishPool.CurCount);
        for (var i = 0; i < 10; i++)
        {
            fishPool.Allocate();
        }
        Debug.LogFormat("fishPool.CurCount:{0}", fishPool.CurCount);
    }
	
	
}
