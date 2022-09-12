using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text m_roomName;

    public string m_name;
   
    public void SetUp(string roomName)
    {
        m_roomName.SetText(roomName);
        m_name = roomName;
    }
    public void OnClick()
    {
        PhotonNetwork.JoinRoom(m_name);
        SceneManager.LoadScene("LoadingMenuScene");
    }
}
