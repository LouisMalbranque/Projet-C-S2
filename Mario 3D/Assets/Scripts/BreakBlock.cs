using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "colliderHead"){
  			Destroy(this.gameObject);
        }
    }
}
