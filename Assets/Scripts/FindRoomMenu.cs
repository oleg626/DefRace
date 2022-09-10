using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class FindRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform roomListContent;
    [SerializeField] private GameObject roomListItemPrefab;

    private List<RoomListItem> m_rooms = new List<RoomListItem>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("room list updated");

        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList)
            {
                Debug.Log("Room " + roomInfo.Name + " is deleted");
                int index = m_rooms.FindIndex(x => x.m_name == roomInfo.Name);
                if (index != -1)
                {
                    Destroy(m_rooms[index].gameObject);
                    m_rooms.RemoveAt(index);
                }
            }
            else
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
}
