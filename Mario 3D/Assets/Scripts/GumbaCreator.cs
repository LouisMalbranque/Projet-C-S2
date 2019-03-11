using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de création des Gumba dans le tuyau vert

public class GumbaCreator : MonoBehaviour
{
	public int capacity = 5;
	public int direction = 0;
	public GameObject player;
	public bool creator=false;

    void FixedUpdate()
    {

    	if (player.transform.position.x>20 && creator==false){
       		StartCoroutine(createGumpa());
       		creator=true;
       }
    }

    IEnumerator createGumpa(){
    	GameObject obj = new GameObject();
    	for (int i=0; i<capacity; i++){
    		obj = new GameObject();
    		obj = Instantiate((GameObject)(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Mario/Prefabs/Characters/gumba.prefab", typeof(GameObject))));
        	
            obj.transform.position = GetComponent<Rigidbody>().position + 4*Vector3.up;
            obj.gameObject.tag = "enemy";
			obj.AddComponent<Rigidbody>();
            obj.AddComponent<MushroomMovement>();
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            obj.transform.eulerAngles = new Vector3(0,-90,0);
            obj.AddComponent<CapsuleCollider>();

    		yield return new WaitForSeconds(2);
    	}
    }	
}
