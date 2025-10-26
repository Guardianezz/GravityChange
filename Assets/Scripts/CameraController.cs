using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private BoxCollider2D worldAABB;

    private PlayerManagement playerManagement;

    private float halfHeight;
    private float halfWidth;    

    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    void Update()
    {
		if (playerManagement == null) //might be null right after a new level load (depending on what is loaded/deleted first)
		{
			playerManagement = FindFirstObjectByType<PlayerManagement>();
		}
        else
        {
			Vector3 playerPos = playerManagement.transform.position;
			float clampedX = Mathf.Clamp(playerPos.x, worldAABB.bounds.min.x + halfWidth, worldAABB.bounds.max.x - halfWidth);
			float clampedY = Mathf.Clamp(playerPos.y, worldAABB.bounds.min.y + halfHeight, worldAABB.bounds.max.y - halfHeight);

			transform.position = new Vector3(clampedX, clampedY, transform.position.z);
		}
	}
}
