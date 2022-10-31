using UnityEngine;
using System.Collections;

public class OrthoCam : MonoBehaviour
{

	public Transform target; // The Object we are following
	public Camera cam; // Main Camera	
	float camsize;
	public float left = 0f; // left edge of the screen
	public float bottom = -5.5f; // bottom of the screen
	public float lead = 2.5f; // front view
	public float above = 5f; // top edge
	public float minView = 5f; // smallest cam view


	void Start()
	{
		cam = Camera.main; // get's main camera
	}

	public void MainGameCam()
	{
		float height = target.position.y + above - bottom; // the height of the camera is the position of target + above - bottom.
		height = Mathf.Max(height, minView); // math function to return the largest number of  the inputs
		height /= 2.0f; //dividing the screen height by 2 to get the center
		height = Mathf.Clamp(height, 5f, 300f); //clamping size values between largest and smallest size
		cam.orthographicSize = height; //pushing calculations through to orthoCam size
		
		transform.position = new Vector3(target.position.x, bottom + height, -10); //this keeps the player in the center
	}

	void Update()
	{
		MainGameCam(); //runs the function MainGameCam().
	}
}
