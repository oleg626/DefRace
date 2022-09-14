using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

interface IRoomListManager
{
    static public List<RoomInfo> m_roomList = new List<RoomInfo>();
}
