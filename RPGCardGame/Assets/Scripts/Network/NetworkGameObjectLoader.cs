using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkGameObjectLoader : MonoBehaviour
{
	public GameObject HostObject;
	public GameObject ClientObject;

	[SerializeField] bool test;

	void Start()
	{
		var manager = NetworkManager.singleton;

		if(test)
		{
			HostObject.SetActive(true);
			ClientObject.SetActive(false);
		}
		else
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
		
	}
}
