using UnityEngine;
using System.Collections;

public class AutomatedEnemyAI : MonoBehaviour {
	bool playerinsight;
	GameObject player;
	float rotationspeed = 5;
public	Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerinsight = GetComponent<EnemySight>().playerinsight;
		if (playerinsight && target){
		

			Vector3 vectorToTarget = target.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationspeed);
		}
	}
}
