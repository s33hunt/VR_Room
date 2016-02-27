using UnityEngine;
using System.Collections;

public class LightLooker : MonoBehaviour {

	public Transform hmd;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(new Vector3(
			hmd.position.x,
			transform.position.y,
			hmd.position.z	
		));
	}
}
