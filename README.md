Unity3d-EventsManager
=====================

simple unity3d events manager


how to use ?

1.Add the scripts(EventsMgr.cs) into your Unity3D-Assets-Path

2.Register your event as enum ,every enum value is an event , such as :

public enum eEventsKey
{

    ControlSystem_RabbitJump,
    
    /*控制系统_兔子跳,*/
}

3.Init Events System before u use it

EventsMgr.GetInstance().Init();

4.Attach your method to the event key:

EventsMgr.GetInstance().AttachEvent(eEventsKey.ControlSystem_RabbitJump, RabbitJump);


5.Trigger the event where u want , and u can add u param to the event , such as:

EventsMgr.GetInstance().TriigerEvent(eEventsKey.ControlSystem_RabbitJump, 10.0f);
 
 
6.Detach the event from method ,if u don't want it:

EventsMgr.GetInstance().DetachEvent(eEventsKey.ControlSystem_RabbitJump, RabbitJump);




Any question see "testEvent.cs" before , this is a demo.




That's all ,

A Simple Events-Manager,

Have Fun.

By xuzhiping
