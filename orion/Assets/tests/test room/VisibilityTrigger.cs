using UnityEngine;
using System.Collections;

public class VisibilityTrigger : MonoBehaviour {
	public AudioSource s1, s2;
	public GameObject SWROD;
	public Animator a;
	SwordController sc;
	bool happened = false, creatureFreaked = false;
	void Start() {
		sc = SWROD.GetComponent<SwordController>();
		SWROD.SetActive(false);
	}


	void OnWillRenderObject()
	{
		if (!happened && !s1.isPlaying) 
		{
			
			s1.Play();
			happened = true;
			SWROD.SetActive(true);
			sc.stage = SwordController.SwordStage.floating;
		}

		if(!creatureFreaked && sc.isGrabbed && !s2.isPlaying)
		{
			creatureFreaked = true;
			s2.Play();
			print("lakjsdlkajsd");
			a.SetBool("isFreaked", true);
		}
	}
}
