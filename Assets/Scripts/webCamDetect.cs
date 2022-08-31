using UnityEngine;
using System.Collections;

public class webCamDetect : MonoBehaviour
{
	public Material camMaterial;
	public int cameraNumber = 0;
	string camName;
	public const string RICOH_DRIVER_NAME = "RICOH THETA UVC";
	//public const string RICOH_DRIVER_NAME = "Intel(R) RealSense(TM) Depth Camera 455  RGB";
	// change to "RICOH THETA V FullHD" for lower resolution 
	// (and thus smaller data size)

	// Audio
	public const int THETA_V_AUDIO_NUMBER = 1;   
	AudioSource audioSource;

	void Awake()
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		Debug.Log("Number of web cams connected: " + devices.Length);

		for (int i = 0; i < devices.Length; i++)
		{
			Debug.Log(i + " " + devices[i].name);
			if (devices[i].name == RICOH_DRIVER_NAME)
			{
				camName = devices[i].name;
			}
		}

		//camName = devices[cameraNumber].name;

		Debug.Log("I am using the webcam named " + camName);

		if (camName != RICOH_DRIVER_NAME)
		{
			Debug.Log("ERROR: " + RICOH_DRIVER_NAME +
				" not found. Install Ricoh UVC driver 1.0.1 or higher. Make sure your camera is in live streaming mode");
		}

		//Renderer rend = this.GetComponentInChildren<Renderer>();
		WebCamTexture mycam = new WebCamTexture();

		mycam.deviceName = camName;
		//rend.material.mainTexture = mycam;
		camMaterial.mainTexture = mycam;

		mycam.Play();

	}
}