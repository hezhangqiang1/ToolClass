/*
 * 脚本功能：资源管理器的池子接口
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 接口池子
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPool<T>
{
    T Allocate();
    bool Recycle(T obj);
}
/// <summary>
/// 工厂池子创建池子
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IObjectFactory<T>
{
    T Create();
}
