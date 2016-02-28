using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
	public enum SwordStage { initial, floating, inHand }
	public SwordStage stage = SwordStage.initial;
	public float speed = 90;
	public GrabbableObject grabob;
	public bool isGrabbed { get { return grabob.IsGrabbed(); } }
	bool wasGrabbed = false;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}



	void Update ()
	{
		if(stage == SwordStage.floating)
		{
			transform.Rotate(0, speed * Time.deltaTime, 0);
		}

		if(isGrabbed && !wasGrabbed)
		{
			stage = SwordStage.inHand;
			rb.useGravity = false;
			rb.isKinematic = true;
			wasGrabbed = true;
		}
		else if(!isGrabbed && wasGrabbed)
		{
			wasGrabbed = false;
			rb.useGravity = true;
			rb.isKinematic = false;
		}
	}
}
