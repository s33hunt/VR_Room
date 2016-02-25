using UnityEngine;
using System.Collections;

public class HelmController : MonoBehaviour {
	public float equipDistance = .4f;
	public GrabbableObject grabob;
	public Transform hmd;
	public GameObject headHelm;
	bool isGrabbed { get { return grabob.IsGrabbed(); } }
	bool helmOnHead = false;

	void Start() { headHelm.SetActive(false); }

	void Update () {
		if(isGrabbed && Vector3.Distance(transform.position, hmd.position) < equipDistance && !helmOnHead) {
			helmOnHead = true;
			headHelm.SetActive(true);
			HMDAlignmentTest.instance.ascii.enabled = true;
			Destroy(gameObject);
		}
	}
}
