/*
 * 消息机制工具类：用来给脚本之间传递消息，不用持有某一方的脚本从而减少代码的耦合性
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassageDispatcher 
{

    private static Dictionary<string, Action<object>> RegisteredMsgs = new Dictionary<string, Action<object>>();


    /// <summary>
    ///注册方法
    /// </summary>
    /// <param name="msgName">方法名</param>
    /// <param name="onMsgReceived"></param>
    public static void Register(string msgName, Action<object> onMsgReceived)
    {
        if (!RegisteredMsgs.ContainsKey(msgName))
        {
            RegisteredMsgs.Add(msgName, _ => { });
        }
        RegisteredMsgs[msgName] += onMsgReceived;
    }
    /// <summary>
    /// 清空所有注册
    /// </summary>
    /// <param name="msgName"></param>
    public static void UnRegisterAll(string msgName)
    {
        RegisteredMsgs.Remove(msgName);
    }
    /// <summary>
    /// 清空特定注册
    /// </summary>
    /// <param name="msgName"></param>
    /// <param name="onMsgReceived"></param>
    public static void UnRegister(string msgName, Action<object> onMsgReceived)
    {
        if (RegisteredMsgs.ContainsKey(msgName))
        {
            RegisteredMsgs[msgName] -= onMsgReceived;
        }
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgName"></param>
    /// <param name="data"></param>
    public static void Send(string msgName, object data)
    {
        if (RegisteredMsgs.ContainsKey(msgName))
        {
            RegisteredMsgs[msgName](data);
        }
    }


}

