using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class RoomMenu : BaseMenu
{
    [SerializeField] TMP_Text m_roomName;
    [SerializeField] GameObject m_startGameButton;
    // Start is called before the first frame update
    void Start()
    {
        m_roomName.SetText(PhotonNetwork.CurrentRoom.Name);
    }

    void Update()
    {
        m_startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LoadingMenuScene");
    }
}
