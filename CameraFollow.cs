using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform follow;
    float myZ;
	
	void Start () {
        myZ = transform.position.z;
	}
	
	
	void Update () {
        transform.position = new Vector3(follow.position.x, follow.position.y, myZ);
	}
}
