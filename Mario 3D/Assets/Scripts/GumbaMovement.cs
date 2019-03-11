using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script de gestion des mouvements des gumbas

public class GumbaMovement : MonoBehaviour
{
	public float speed = 0.05f;
	public int direction = -1;

	void FixedUpdate(){
		GetComponent<Rigidbody>().position += Vector3.right*speed*direction;
		

	}
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Wall"){
			direction = -direction;
			transform.eulerAngles = new Vector3(0,direction*90,0);
		}
	}
}
