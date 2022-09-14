using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : BaseMenu
{
    [SerializeField] Button joinRandomRoomButton;
    public void Update()
    {
        int roomCount = PhotonNetwork.CountOfRooms;
        joinRandomRoomButton.interactable = roomCount > 0;
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        SceneManager.LoadScene("LoadingMenuScene");
    }

    public void createRoom(TMP_InputField roomName)
    {
        if (string.IsNullOrEmpty(roomName.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomName.text);
        SceneManager.LoadScene("LoadingMenuScene");
    }
}
