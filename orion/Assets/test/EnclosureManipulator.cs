using UnityEngine;
using System.Collections;

public class EnclosureManipulator : MonoBehaviour
{
	public GameObject[] asegs, bsegs;
	bool locked = true;
	Transform center;

	void Start()
	{
		center = transform.Find("center");
	}

	void Update ()
	{
		if(CCInputManager.instance.k2Rbtns[7] && locked) { unlock(); }

		if (!locked)
		{
			foreach (GameObject g in asegs)
			{
				g.transform.position = center.position + (Vector3.down * 5 * (1 - CCInputManager.instance.k2Sliders[7]));
			}
		}
		
	}

	void unlock()
	{
		for (int i = 0; i < asegs.Length; i++) {
			asegs[i].transform.localScale *= 1.1f;
		}
		locked = false;
	}
}