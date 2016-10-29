using UnityEngine;
using System.Collections;

public class quaterniontest : MonoBehaviour {
	public GameObject cube;

	Quaternion cubeQuaternion;
	// Use this for initialization
	void Start () {
		cubeQuaternion = cube.transform.rotation;

	}

	float n =0;
	// Update is called once per frame
	void Update () {

		n += Time.deltaTime;
		print (n);

		cube.transform.rotation = Quaternion.Lerp (cube.transform.rotation, cubeQuaternion*Quaternion.Euler (0, 180, 0),n*0.1f);
	}
}