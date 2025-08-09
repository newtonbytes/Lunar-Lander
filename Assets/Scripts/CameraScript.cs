using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public PlayerController pc;


	Quaternion rotation;

	void Awake()
	{
		rotation = transform.rotation;
	}

	void LateUpdate()
	{
		if (pc.height < pc.heightThreshold)
		{
			Debug.Log("Player is beneath threshold");
		}

		transform.rotation = rotation;
	}
}
