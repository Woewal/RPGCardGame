using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class Action : Node
{
	[Input] public Action Previous;
	[Output] public Action Next;

	public abstract void ExecuteAction();

	public void Finish()
	{
		NodePort nextPort;
		nextPort = GetOutputPort("Next");
		for (int i = 0; i < nextPort.ConnectionCount; i++)
		{
			NodePort connection = nextPort.GetConnection(i);
			(connection.node as Action).ExecuteAction();
		}
	}
}