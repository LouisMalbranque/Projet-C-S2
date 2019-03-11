using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script de gestion des mouvements des champignons

public class MushroomMovement : MonoBehaviour
{
	public float speed = 0.1f;
	private int direction = -1;

	void FixedUpdate(){
		GetComponent<Rigidbody>().position += Vector3.right*speed*direction;
	}	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Wall"){
			direction = -direction;
		}
	}
}
