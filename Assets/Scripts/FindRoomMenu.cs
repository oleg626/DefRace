using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class FindRoomMenu : BaseMenu
{
    [SerializeField] private Transform roomListContent;
    [SerializeField] private GameObject roomListItemPrefab;


    private List<RoomListItem> m_rooms = new List<RoomListItem>();

    private void Start()
    {
        OnRoomListUpdate(IRoomListManager.m_roomList);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        IRoomListManager.m_roomList = roomList;
        Debug.Log("Room menu updated");

        foreach (RoomListItem room in m_rooms)
        {
            Destroy(room.gameObject);
        }

        foreach (RoomInfo roomInfo in IRoomListManager.m_roomList)
        {
            Debug.Log("Room " + roomInfo.Name + " is added");
            GameObject item = Instantiate(roomListItemPrefab, roomListContent);
            if (item != null)
            {
                m_rooms.Add(item.GetComponent<RoomListItem>());
                m_rooms[m_rooms.Count - 1].SetUp(roomInfo.Name);
            }
        }
    }
}
