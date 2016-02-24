using UnityEngine;
using System.Collections;

public class HMDAlignmentTest : MonoBehaviour
{
	public static HMDAlignmentTest instance;
	public Transform hmd, cameraPin;
	OVRTracker ovrt = new OVRTracker();
	Transform marker;
	public AsciiImageEffect.Ascii ascii;

	void Start()
	{
		instance = this;
		marker = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		marker.localScale = Vector3.one * 0.1f;
		
	}
	bool mbuttonpressed = false;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			StartCoroutine("OrientToTheDungeon");
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			ascii.enabled = !ascii.enabled;
		}


		if (CCInputManager.instance.k2Mbtns[7] && !mbuttonpressed) {
			mbuttonpressed = true;
			ascii.enabled = !ascii.enabled;
		}else if (!CCInputManager.instance.k2Mbtns[7] && mbuttonpressed) {
			mbuttonpressed = false;
		}
	}

	IEnumerator OrientToTheDungeon()
	{
		//recenter
		UnityEngine.VR.InputTracking.Recenter();
		//wait a frame
		yield return null;
		//get tracker pose
		OVRPose p = ovrt.GetPose(Time.time);
		//set marker in hmd local space
		marker.parent = hmd;
		marker.localPosition = p.position;
		marker.rotation = p.orientation;
		marker.parent = null;
		//set entire environment position to position of marker (aka, pin it to the tracking camera's position)
		cameraPin.position = marker.position;
	}
}
//print(ovrt.isPositionTracked+":"+p.position+":"+p.orientation);

/*if (Input.GetKeyDown(KeyCode.Space))
	{
		//get tracker pose
		OVRPose p = ovrt.GetPose(Time.time);
		print(ovrt.isPositionTracked);
		print(p.position);
		print(p.orientation);
		marker.parent = hmd;
		marker.localPosition = p.position;
		marker.rotation = p.orientation;
		marker.parent = null;
		cameraPin.position = marker.position;
	}

	if (Input.GetKeyDown(KeyCode.R))
	{
		//recenter
		UnityEngine.VR.InputTracking.Recenter();
	}*/
