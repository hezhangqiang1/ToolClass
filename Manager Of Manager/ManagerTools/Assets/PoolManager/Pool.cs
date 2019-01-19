﻿/*
 * 资源池的抽象类
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : IPool<T>
{
    protected IObjectFactory<T> mFactory;
    protected Stack<T> mCacheStack = new Stack<T>();
    public int CurCount
    {
        get { return mCacheStack.Count; }
    }
    protected int mMaxCount = 5;
    public virtual T Allocate()
    { return mCacheStack.Count == 0 ? mFactory.Create() : mCacheStack.Pop();
    }
    public abstract bool Recycle(T obj);

}
public class CustomObjectFactory<T> : IObjectFactory<T>
{
    protected Func<T> mFactoryMethod;

    public CustomObjectFactory(Func<T> factoryMethod)
    {
        mFactoryMethod = factoryMethod;

    }
    public T Create() { return mFactoryMethod(); }

}
public class SimpleObjectPool<T> : Pool<T>
{
    readonly Action<T> mResetMethod;
    public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
    {
        mFactory = new CustomObjectFactory<T>(factoryMethod);
        mResetMethod = resetMethod;
        for (var i = 0; i < initCount; i++)
        {
            mCacheStack.Push(mFactory.Create());
        }
    }
    public override bool Recycle(T obj)
    {
        if (mResetMethod != null)
        {
            mResetMethod(obj);
        }
        mCacheStack.Push(obj);
        return true;
    }
}


