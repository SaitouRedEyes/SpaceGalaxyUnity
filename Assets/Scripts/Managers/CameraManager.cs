using UnityEngine;
using System.Collections;

/// <summary>
/// Camera manager.
/// </summary>
public class CameraManager : MonoBehaviour 
{
	private Camera mainCamera;
	private Player player;
	
	// Use this for initialization
	void Start () 
	{
		mainCamera = Camera.main;
		player = (Player)GameObject.FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () 
	{
		mainCamera.transform.localPosition = new Vector3(player.transform.localPosition.x,
														 player.transform.localPosition.y,
														 mainCamera.transform.localPosition.z);
		
	}
}
