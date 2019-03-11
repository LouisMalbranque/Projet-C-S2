using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gere la position de la caméra pour qu'elle soit toujours positionnée en suivis du personnage peu importe son orientation

public class CameraPosition : MonoBehaviour
{ 
//define player game object
public GameObject player;

//wait for lateupdate
void LateUpdate()
  {
   transform.position = new Vector3(player.transform.position.x-5f, 5f, -10f);
   transform.eulerAngles = new Vector3(0,5,0);
  }
}
