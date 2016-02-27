using UnityEngine;
using System.Collections;

public class EnclosureManipulator : MonoBehaviour
{
	public GameObject[] asegs, bsegs;
	bool locked = true;
	Transform center;
	public AudioSource unlocksound, slidesound;

	void Start()
	{
		center = transform.Find("center");
	}
	bool unlockstarted = false;
	void Update ()
	{
		if(CCInputManager.instance.k2Rbtns[7] && locked) { unlockstarted = true; }

		if(unlockstarted && locked) { unlock(); }

		if (!locked) {
			foreach (GameObject g in asegs) {
				g.transform.position = center.position + (Vector3.down * 5 * (1 - CCInputManager.instance.k2Sliders[7]));
			}
			if(CCInputManager.instance.k2Sliders[7] != lastSlideVal && !sound2played) {
				slidesound.Play();
				sound2played = true;
			}
			if(CCInputManager.instance.k2Sliders[7] == 0 && !triggeredhelm) { HelmController.instance.helmstage = HelmController.HelmStage.floating; triggeredhelm = true; }
		}
		lastSlideVal = CCInputManager.instance.k2Sliders[7];
	}

	float lastSlideVal = 0;
	bool sound1played = false, sound2played = false, triggeredhelm = false;
	public float asegScaleMax = 1.1f;
	void unlock()
	{
		if (!unlocksound.isPlaying && !sound1played) { unlocksound.Play(); sound1played = true; }
		for (int i = 0; i < asegs.Length; i++) {
			asegs[i].transform.localScale += (Vector3.one * Time.deltaTime * 0.1f);
			if (asegs[i].transform.localScale.x >= asegScaleMax) {
				asegs[i].transform.localScale = Vector3.one * asegScaleMax;
				locked = false;
			}
		}	
	}
}