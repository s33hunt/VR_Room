using UnityEngine;
using System.Collections;

public class ghoulController : MonoBehaviour {
	public GameObject ghoulMesh;
	public AudioSource audio;
	public float speed = -1;
	void FixedUpdate () {
		transform.Rotate(0, speed, 0);
	}
	bool ghoulvisible = true;
	void Update()
	{
		if(!ghoulvisible && HMDAlignmentTest.instance.ascii.enabled) {
			audio.enabled = 
			ghoulvisible = 
			ghoulMesh.GetComponent<SkinnedMeshRenderer>().enabled = true; }
		if (ghoulvisible && !HMDAlignmentTest.instance.ascii.enabled) {
			audio.enabled =
			ghoulvisible = 
			ghoulMesh.GetComponent<SkinnedMeshRenderer>().enabled = false; }
	}
}
