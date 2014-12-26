using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fieldofViewAngle = 110f;
	public bool playerinsight;
	public Vector3 personalLastSighting;
	public LayerMask visible; //ie. everything but triggers
	Transform face;
	Vector3 playerdirection;
	Vector3 myfacedirection;
	GameObject player;
	bool alive;
	float angle;
	CircleCollider2D sightrange;
	// Use this for initialization
	void Start () {
		face = transform.Find("mfw");
		sightrange = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player){
		bool targetactive = player.GetComponent<ActivePlayer>().active;
		if (!targetactive)
			GetComponent<AutomatedEnemyAI>().target = null;
		}
		if (playerinsight)
			GetComponent<SpriteRenderer>().color = Color.red;
		else GetComponent<SpriteRenderer>().color = Color.green;
		if (alive){
			playerdirection = player.transform.position-transform.position;
			myfacedirection = face.position-transform.position;
			 angle = Vector3.Angle (playerdirection,myfacedirection);
			if (angle < fieldofViewAngle/2){

				RaycastHit2D hit = Physics2D.Raycast(transform.position,playerdirection,100,visible);
			
				if (hit.transform.gameObject.CompareTag("Player"))
				playerinsight = true;
				else playerinsight = false;
			}
			else if (angle > fieldofViewAngle/2)playerinsight = false;
		}

	}
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.CompareTag("Player")){

			if (other.gameObject.GetComponent<ActivePlayer>().active == true){
				player = other.gameObject;
				Debug.Log ("NONO");
				GetComponent<AutomatedEnemyAI>().target = player.transform;
				alive = true;}
			/*else if (other.gameObject.GetComponent<ActivePlayer>().active == false){
				player = null;

				GetComponent<AutomatedEnemyAI>().target = null;
				}*/

		}

	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.CompareTag("Player")){
			alive = false;
			player = null;
			playerinsight = false;
		}
	}
}
