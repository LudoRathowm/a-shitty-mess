using UnityEngine;
using System.Collections;

public class ActivePlayer : MonoBehaviour {
	public bool active = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (active)
			GetComponent<SpriteRenderer>().color = Color.blue;
		else GetComponent<SpriteRenderer>().color = Color.grey;
	}
}
