using UnityEngine;
using System.Collections;

public class sintest : MonoBehaviour {

	public float tmp;
	public float amplitude;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x + 1f
			,amplitude * Mathf.Sin (Time.frameCount * tmp ),transform.position.z);
	}
}
