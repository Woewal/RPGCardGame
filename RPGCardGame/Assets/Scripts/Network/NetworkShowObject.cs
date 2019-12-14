using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkShowObject : MonoBehaviour
{
	enum NetworkTarget { Client, Host }

	[SerializeField] NetworkTarget Target;

	void Awake()
	{
		var manager = NetworkManager.singleton;

		if (NetworkServer.active)
		{
			if (Target != NetworkTarget.Host)
				gameObject.SetActive(false);
		}
		else
		{
			if(Target != NetworkTarget.Client)
				gameObject.SetActive(false);
		}

	}
}
