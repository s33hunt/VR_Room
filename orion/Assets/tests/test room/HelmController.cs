using UnityEngine;
using System.Collections;

public class HelmController : MonoBehaviour {
	public enum HelmStage { initial, floating, resting }
	public HelmStage helmstage = HelmStage.initial;

	public float
		rotationPerSecond = 1f,
		speed = 0.01f,
		equipDistance = .4f;
	public GrabbableObject grabob;
	public Transform hmd;
	public GameObject headHelm, floatnHelm;
	bool isGrabbed { get { return grabob.IsGrabbed(); } }
	bool helmOnHead = false;
	Transform startpos, endpos;

	void Start() {
		floatnHelm.SetActive(false);
		headHelm.SetActive(false);
		startpos = transform.parent.Find("helm start");
		endpos = transform.parent.Find("helm end");
		transform.position = startpos.position;
		GetComponent<Rigidbody>().useGravity = false;
	}

	void Update () {
		
		if(helmstage == HelmStage.floating)
		{
			floatnHelm.SetActive(true);
			transform.position = Vector3.Lerp(transform.position, endpos.position, 0.5f * Time.deltaTime * speed);
			transform.Rotate(0, rotationPerSecond * Time.deltaTime, 0);

			if (Vector3.Distance(transform.position, endpos.position) < 0.05f)
			{
				GetComponent<Rigidbody>().useGravity = true;
				helmstage = HelmStage.resting;
			}
		}
		else if (helmstage == HelmStage.resting)
		{
			if (isGrabbed && Vector3.Distance(transform.position, hmd.position) < equipDistance && !helmOnHead)
			{
				helmOnHead = true;
				headHelm.SetActive(true);
				HMDAlignmentTest.instance.ascii.enabled = true;
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision c)
	{
		print("sladfjk");
	}
}
