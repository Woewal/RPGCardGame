using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
	public static CursorManager Instance;
	public PlayerColors PlayerColors;
	public Cursor CursorPrefab;
	public RectTransform CursorParent;
	public Dictionary<int, Cursor> Cursors = new Dictionary<int, Cursor>();

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		PlayerManager.Instance.OnPlayerAdded += RegisterCursor;
	}

	public void RegisterCursor(PlayerInfo player)
	{
		var cursor = Instantiate(CursorPrefab, CursorParent);
		cursor.GetComponent<Image>().color = PlayerColors.Colors[player.Number - 1];
		Debug.Log("Registered cursor id: " + player.Number);
		Cursors.Add(player.Number, cursor);

		player.Cursor = cursor;
		player.Input.OnGyroscopeUpdate += (amount) =>
		{
			MoveCursor(player.Cursor, amount);
		};
		cursor.OnCast += (position) => { Debug.Log("Player (" + player.Number + ") clicked at position (" + position + ")!"); };
		player.Input.OnReleaseButton += () =>
		{
			var position = cursor.GetWorldPosition();
			if (position != null)
				player.Cursor.OnCast?.Invoke((Vector3)position);
		};
	}

	public void MoveCursor(Cursor cursor, Vector2 amount)
	{
		cursor.TargetPosition = new Vector3(Screen.width / 2 + amount.x, Screen.height / 2 + amount.y);
	}
}
