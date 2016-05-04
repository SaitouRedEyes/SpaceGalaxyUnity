using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{	
	private Vector3 moveDirection;
	
	//for UpdatePlayer()
	private Vector2 speed;
	
	// Use this for initialization
	void Start () { speed = new Vector2(0.1f, 0.1f); }
	
	// Update is called once per frame
	void Update () 
	{
		UpdatePlayer();
		//UpdatePlayer2();
	}
	
	/// <summary>
	/// Call a method to move the player in 9 directions depending on keyDown.
	/// </summary>
	private void UpdatePlayer()
	{
		if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) 
			Move(-speed.x, speed.y, 45.0f);
		else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) 
			Move(-speed.x, -speed.y, 135.0f);
		else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
			Move(speed.x, speed.y, 315.0f);
		else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
			Move(speed.x, -speed.y, 225.0f);
		else if(Input.GetKey(KeyCode.LeftArrow))
			Move(-speed.x, 0, 90.0f);
		else if(Input.GetKey(KeyCode.RightArrow))
			Move(speed.x, 0, 270.0f);
		else if(Input.GetKey(KeyCode.UpArrow))
			Move(0, speed.y, 0);
		else if(Input.GetKey(KeyCode.DownArrow))
			Move(0, -speed.y, 180.0f);
	}
	
	private void UpdatePlayer2()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
			this.transform.Rotate(Vector3.forward, 0.1f);
		else if(Input.GetKey(KeyCode.RightArrow))
			this.transform.Rotate(Vector3.back, 0.1f);
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), -0.01f);
			moveDirection = this.transform.TransformDirection(moveDirection);
			moveDirection *= 0.01f;
		}
		
		this.transform.localPosition += moveDirection;
	}
	
	/// <summary>
	/// Translate and rotate the player.
	/// </summary>
	/// <param name='speedX'>
	/// Speed x.
	/// </param>
	/// <param name='speedY'>
	/// Speed y.
	/// </param>
	/// <param name='rotationAngle'>
	/// Rotation angle.
	/// </param>
	private void Move(float speedX, float speedY, float rotationAngle)
	{
		this.transform.localPosition = new Vector3(this.transform.localPosition.x + speedX,
														this.transform.localPosition.y + speedY,
														this.transform.localPosition.z);
			
		this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x,
														this.transform.localRotation.y,
														rotationAngle);
	}
}