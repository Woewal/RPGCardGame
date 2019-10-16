using UnityEngine;

namespace CardGame
{
	public static class Physics
	{
		public static void Push(Rigidbody rigidbody, float force, Vector3 position, float radius)
		{
			rigidbody.AddExplosionForce(force, position, radius);
		}

		public static void Pull(Rigidbody rigidbody, float force, Vector3 position, float radius)
		{
			Vector3 relativePosition = position - rigidbody.transform.position;
			float distance = relativePosition.magnitude;
			rigidbody.AddForce(relativePosition.normalized * (force * distance / radius));
		}
	}
}