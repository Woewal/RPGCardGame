using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SpellNode : Node {

	[Output] public Action Next;
	[Output] public CastInfo CastInfo;

	public void GoNext()
	{
		NodePort nextPort;
		nextPort = GetOutputPort("Next");
		for (int i = 0; i < nextPort.ConnectionCount; i++)
		{
			NodePort connection = nextPort.GetConnection(i);
			(connection.node as Action).ExecuteAction();
		}
	}

	public override object GetValue(NodePort port)
	{
		return base.GetValue(port);
	}
}