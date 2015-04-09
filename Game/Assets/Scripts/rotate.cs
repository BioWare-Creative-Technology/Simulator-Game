using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * -1);
	}
}
