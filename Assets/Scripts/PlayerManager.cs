using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	GameObject controller;

	int kills;
	int deaths;
	static int players;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{ 
		//Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
		controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "defCar"), new Vector3(10, 0, 4 * (PV.ViewID % 3) - 4), Quaternion.Euler(0, 90, 0), 0, new object[] { PV.ViewID });
	}

	public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();

		deaths++;

		Hashtable hash = new Hashtable();
		hash.Add("deaths", deaths);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	public void GetKill()
	{
		PV.RPC(nameof(RPC_GetKill), PV.Owner);
	}

	[PunRPC]
	void RPC_GetKill()
	{
		kills++;

		Hashtable hash = new Hashtable();
		hash.Add("kills", kills);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	public static PlayerManager Find(Player player)
	{
		return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x.PV.Owner == player);
	}
}