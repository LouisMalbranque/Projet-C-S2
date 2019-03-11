using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script attaché aux blocs de bois pour qu'ils se détruisent lors d'une collision avec le joueur

public class BreakBlock : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "colliderHead"){
  			Destroy(this.gameObject);
        }
    }
}
