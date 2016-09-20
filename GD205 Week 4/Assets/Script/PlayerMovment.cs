using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	public float WalkSpeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xWalk = Input.GetAxis ("Horizontal");
		float zWalk = Input.GetAxis ("Vertical");
		transform.Translate (xWalk * WalkSpeed,0,zWalk * WalkSpeed);
	}
}
