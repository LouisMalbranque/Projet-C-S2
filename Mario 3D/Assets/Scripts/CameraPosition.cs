using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{ 
//define player game object
public GameObject player;

//wait for lateupdate
void LateUpdate()
  {
   transform.position = new Vector3(player.transform.position.x, 5f, -10f);
  }
}
