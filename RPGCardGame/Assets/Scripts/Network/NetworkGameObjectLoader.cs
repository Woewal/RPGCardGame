using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkGameObjectLoader : MonoBehaviour
{
	public GameObject HostObject;
	public GameObject ClientObject;

	void Start()
	{
		var manager = NetworkManager.singleton;

		if(NetworkServer.connections.Count > 0)
		{
			if (NetworkServer.active)
			{
				HostObject.SetActive(true);
				ClientObject.SetActive(false);
			}
			else
			{
				HostObject.SetActive(false);
				ClientObject.SetActive(true);
			}
		}
		else
		{
			HostObject.SetActive(true);
			ClientObject.SetActive(false);
		}
	}
}
