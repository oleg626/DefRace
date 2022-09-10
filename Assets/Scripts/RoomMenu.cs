using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class RoomMenu : MonoBehaviour
{
    [SerializeField] TMP_Text m_roomName;
    // Start is called before the first frame update
    void Start()
    {
        m_roomName.SetText(PhotonNetwork.CurrentRoom.Name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LoadingMenuScene");
    }
}
