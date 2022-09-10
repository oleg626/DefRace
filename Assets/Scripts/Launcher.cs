using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
	public static Launcher Instance;

	[SerializeField] TMP_InputField roomNameInputField;
	[SerializeField] TMP_Text errorText;
	[SerializeField] TMP_Text roomNameText;
	[SerializeField] Transform playerListContent;
	[SerializeField] GameObject PlayerListItemPrefab;
	[SerializeField] GameObject startGameButton;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		Debug.Log("Connecting to Master");
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
		PhotonNetwork.JoinLobby();
		PhotonNetwork.AutomaticallySyncScene = true;
	}

	public override void OnJoinedLobby()
	{
		Debug.Log("Joined Lobby");
		SceneManager.LoadScene("MainMenuScene");
	}

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
		SceneManager.LoadScene("RoomMenuScene");
		Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
		Debug.Log("Room creation failed: " + message);
		SceneManager.LoadScene("MainMenuScene");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
		SceneManager.LoadScene("MainMenuScene");
    }

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
		Debug.Log("Room list updated");
    }
}