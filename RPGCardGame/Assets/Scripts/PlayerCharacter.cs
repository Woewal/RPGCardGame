using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	static CinemachineTargetGroup targetFollowGroup;

	public PlayerInfo Info;

    public void Initiate(PlayerInfo player)
	{
		Info = player;
	}

	void Start()
	{
		if (targetFollowGroup == null)
			targetFollowGroup = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();

		targetFollowGroup.AddMember(transform, 1, 6);
		
	}
}
