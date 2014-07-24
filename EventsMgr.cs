//*******************************************
//文件名称: 简单的全局事件管理
//文件描述:	简单的全局事件管理系统，主要用于事件触发（新手引导）
//参与编写人: 徐志平
//*******************************************


using UnityEngine;
using System.Collections.Generic;


public enum eEventsKey
{
    控制系统_兔子跳,
    控制系统_兔子向左走,
    控制系统_兔子停止向左走,
    控制系统_兔子向右走,
    控制系统_兔子停止向右走,
}


public class EventsMgr  {

    private static EventsMgr instance;
    public static EventsMgr GetInstance()
    {
        if (instance == null)
        {
            instance = new EventsMgr();
        }
        return instance;
    }


    //公共委托事件
    public delegate void CommonEvent(object data);

    //事件列表
    public Dictionary<eEventsKey, CommonEvent> m_dicEvents = new Dictionary<eEventsKey, CommonEvent>();

    
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        foreach (eEventsKey key in eEventsKey.GetValues(typeof(eEventsKey)))
        {
            AddDelegate(key);
        }
    }


    /// <summary>
    ///  添加一个回调事件
    /// </summary>
    private void AddDelegate(eEventsKey key)
    {
        //Debug.Log(" 添加一个回调 : "+ key);
        m_dicEvents.Add(key, delegate(object data) { });
    }


    /// <summary>
    /// 事件触发
    /// </summary>
    public void TriigerEvent(eEventsKey key, object param)
    {
        if (m_dicEvents.ContainsKey(key))
        {
            //Debug.Log(" 事件回调 : " + key);
            m_dicEvents[key](param);
        }
        else
        {
            Debug.LogError("没有这个定义的事件:" + key);
        }
    }

    /// <summary>
    /// 事件绑定
    /// </summary>
    public void AttachEvent(eEventsKey strEventKey, CommonEvent attachEvent)
    {
        if (m_dicEvents.ContainsKey(strEventKey))
        {
            //Debug.Log(" 事件绑定 : " + strEventKey);
            m_dicEvents[strEventKey] += attachEvent;
        }
        else
        {
            Debug.LogError("没有这个定义的事件:" + strEventKey);
        }
    }


    /// <summary>
    /// 去除事件绑定
    /// </summary>
    public void DetachEvent(eEventsKey strEventKey, CommonEvent attachEvent)
    {
        if (m_dicEvents.ContainsKey(strEventKey))
        {
            //Debug.Log("去除事件绑定 : " + strEventKey);
            m_dicEvents[strEventKey] -= attachEvent;
        }
        else
        {
            Debug.LogError("没有这个定义的事件:" + strEventKey);
        }
    }
}
