using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyManager : NetworkBehaviour
{

	public int playersConnected;

	void Start()
	{
		NetworkDiscovery.onReceivedServerResponse += (NetworkDiscovery.DiscoveryInfo info) =>
		{
			Debug.Log(info);
		};

		NetworkServer.RegisterHandler<ConnectMessage>(OnConnected);

	}

	void OnConnected(NetworkConnection conn, ConnectMessage message)
	{
		Debug.Log("Client connected");
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) || Input.touchCount > 0)
			Debug.Log(NetworkManager.singleton.networkAddress);	
	}

	public void Host()
	{
		var manager = NetworkManager.singleton;
		manager.networkAddress = GetLocalIPAddress();
		manager.StartServer();
		NetworkDiscovery.SendBroadcast();
	}

	public void StartGame()
	{
		NetworkManager.singleton.ServerChangeScene("TankMinigame");
	}

	string GetLocalIPAddress()
	{
		var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
		foreach (var ip in host.AddressList)
		{
			if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			{
				return ip.ToString();
			}
		}

		throw new System.Exception("No network adapters with an IPv4 address in the system!");
	}
}
