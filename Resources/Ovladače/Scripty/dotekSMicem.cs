using UnityEngine;
using System.Collections;

public class dotekSMicem : MonoBehaviour {
	public bool dotek = false;

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "mic")
		{
			dotek = true;
		}
		
	}
	
}
