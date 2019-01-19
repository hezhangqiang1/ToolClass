/*
 * 单例模式模板 如果⼀一个游戏需要 10 个各种各样的 Manager，
 * 那么单例代码要复制粘贴好多遍，从⽽而导致重复的代码太多。
 * 所以模板使用泛型和反射的方法解决这个问题。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public abstract class Singleton<T> where T : Singleton<T>
{
    protected static T mInstance = null;
    protected Singleton() {  }
    public static T Instance
    {
        get
        {
            if (mInstance == null)
            { // 先获取所有⾮非public的构造⽅方法 
                var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                // 从ctors中获取⽆无参的构造⽅方法
                var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null) throw new Exception("Non-public ctor() not found!");
                // 调⽤用构造⽅方法
                mInstance = ctor.Invoke(null) as T; }
                return mInstance;
            }
        }
}




