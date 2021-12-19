using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformParent : MonoBehaviour
{
	// Start is called before the first frame update
	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.transform.parent = transform;
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		coll.transform.parent = null;
	}
}
