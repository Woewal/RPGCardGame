using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTester : MonoBehaviour
{
	public GameObject Cursor;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<PointerInput>().OnUpdate += MoveCursor;
    }

	void MoveCursor(Vector2 position)
	{
		Cursor.transform.localPosition = position;
	}

}
