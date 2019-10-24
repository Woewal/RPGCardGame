using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
	NavMeshAgent navMeshAgent;
	Rigidbody rgbd;

	[SerializeField] GameObject[] points;

	void Awake()
	{
		rgbd = GetComponent<Rigidbody>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		StartCoroutine(Navigate());
	}

	void Update()
	{
	}

	IEnumerator Navigate()
	{
		while (true)
		{
			int randomNumber = Random.Range(0, points.Length);
			navMeshAgent.destination = points[randomNumber].transform.position;
			yield return new WaitForSeconds(5f);
		}
	}


}
