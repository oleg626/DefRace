using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BaseMenu : MonoBehaviourPunCallbacks, IRoomListManager
{
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Room list updated");
        base.OnRoomListUpdate(roomList);
        IRoomListManager.m_roomList.Clear();
        foreach (RoomInfo info in roomList)
        {
            if (!info.RemovedFromList)
                IRoomListManager.m_roomList.Add(info);
        }
    }

}
