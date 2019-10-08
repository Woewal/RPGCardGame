using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMovement : MonoBehaviour, IDragHandler, IEndDragHandler
{
	private bool dragging;
	Vector3 lastPosition;
	RectTransform rectTransform;
	Card card;
	public Vector2 velocity;
	[SerializeField] float speed;

	public float DeaccelerationRate;

	void Start()
	{
		card = GetComponent<Card>();
		rectTransform = GetComponent<RectTransform>();
	}

	public void Update()
	{
		if (dragging)
		{
			lastPosition = transform.position;
			transform.position = Vector3.Lerp(transform.position, Input.mousePosition, Time.deltaTime * speed);
		}
		else
		{
			if (transform.position.x > Screen.width && velocity.x > 0)
			{
				Debug.Log("past right screne");
				velocity = Vector3.Reflect(velocity, Vector3.left);
			}
			else if (transform.position.x < 0 && velocity.x < 0)
			{
				Debug.Log("past left screne");
				velocity = Vector3.Reflect(velocity, Vector3.right);
			}
			else if(transform.position.y < 0 && velocity.y < 0)
			{
				velocity = Vector3.Reflect(velocity, Vector3.up);
			}

			if (transform.position.y - rectTransform.rect.height / 2 > Screen.height && velocity.y > 0)
			{
				if(card.Cast())
				{
					Destroy(gameObject);
				}
				else
				{
					Debug.Log("Failed");
					velocity = Vector3.Reflect(velocity, Vector3.down);
				}
			}

			
		}
	}

	public void FixedUpdate()
	{
		if(!dragging)
		{
			velocity *= DeaccelerationRate;
			transform.position = (Vector2)transform.position + velocity;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		velocity = Vector3.zero;
		dragging = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		velocity = transform.position - lastPosition;
		dragging = false;
	}
}