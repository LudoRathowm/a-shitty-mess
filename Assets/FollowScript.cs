using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
	public Transform victim;
	NavMeshAgent navcomponent;

	// Use this for initialization
	void Start () {
		navcomponent = GetComponent<NavMeshAgent>();
		navcomponent.SetDestination(victim.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (victim){
			navcomponent.SetDestination(victim.position);
		}

	}
}
