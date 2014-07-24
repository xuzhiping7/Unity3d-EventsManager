//*******************************************
//文件名称: 测试全局事件管理系统
//文件描述:	测试步骤  初始化，绑定事件，触发事件，消除事件。
//参与编写人: 徐志平
//*******************************************


using UnityEngine;
using System.Collections;

public class testEvent : MonoBehaviour {


	void Start () {

        EventsMgr.GetInstance().Init();

        attachEvents();

        TriggerEvents();

        detachrEvents();
	}

    void attachEvents()
    {
        EventsMgr.GetInstance().AttachEvent(eEventsKey.控制系统_兔子跳, RabbitJump);
        EventsMgr.GetInstance().AttachEvent(eEventsKey.控制系统_兔子向右走, RabbitRight);
        EventsMgr.GetInstance().AttachEvent(eEventsKey.控制系统_兔子停止向右走, RabbitStopRight);
    }

    void TriggerEvents()
    {
        EventsMgr.GetInstance().TriigerEvent(eEventsKey.控制系统_兔子跳, 10.0f);
        EventsMgr.GetInstance().TriigerEvent(eEventsKey.控制系统_兔子向右走, 5.0f);
        EventsMgr.GetInstance().TriigerEvent(eEventsKey.控制系统_兔子停止向右走, 5.0f);
    }

    void detachrEvents()
    {
        EventsMgr.GetInstance().DetachEvent(eEventsKey.控制系统_兔子跳, RabbitJump);
        EventsMgr.GetInstance().DetachEvent(eEventsKey.控制系统_兔子向右走, RabbitRight);
        EventsMgr.GetInstance().DetachEvent(eEventsKey.控制系统_兔子停止向右走, RabbitStopRight);
    }


    void RabbitJump(object data)
    {
        Debug.Log("RabbitJump JumpHeight:" + (float)data);
    }

    void RabbitRight(object data)
    {
        Debug.Log("RabbitRight Speed:" + (float)data);
    }

    void RabbitStopRight(object data)
    {
        Debug.Log("RabbitStop");
    }

}
