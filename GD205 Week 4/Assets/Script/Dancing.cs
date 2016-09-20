using UnityEngine;
using System.Collections;

public class Dancing : MonoBehaviour {
	bool dance;
	public enum groupRotate {group1, group2}
	public groupRotate Group = groupRotate.group1;

	Quaternion rotRight, rotLeft;

	void Start () 
	{

		dance = false;
		rotLeft = Quaternion.Euler (0, -1, 0);
		rotRight = Quaternion.Euler (0, 1, 0);
	}

	void Update()
	{
		if(Group == groupRotate.group1){
			transform.rotation *= rotRight;
		}
		if(Group == groupRotate.group2){
			transform.rotation *= rotRight;
		}
	}
}
	