using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script de création des bonus dans les boites à bonus (champigions, pièces...)

public enum Type
{
    Life=1, Power=2, Coins=3
};

public class MushroomCreator : MonoBehaviour
{
	public bool isFull = true;
    public Type type; 
    private int coins = 5;
    private GameObject obj;

    void OnCollisionEnter(Collision col)
    {
        string tag;

        if (col.collider.name == "colliderHead" && isFull){
        	
            string assetPath = "";
            switch (type){
                case Type.Life:
                    assetPath = "Assets/Mario/Prefabs/Scene Pickups/prefab_pickup_mushroom_extralife.prefab";
                    tag = "Life";
                    break;
                case Type.Power:
                    assetPath = "Assets/Mario/Prefabs/Scene Pickups/prefab_pickup_mushroom_powerup.prefab";
                    tag = "Power";
                    break;
                case Type.Coins:
                    MovementMario.coin++;
                    coins --;
                    assetPath = "Assets/Mario/Prefabs/Scene Pickups/prefab_pickup_coin.prefab";
                    tag = "Piece";
                    break;
                default:
                    assetPath = "Assets/Mario/Prefabs/Scene Pickups/prefab_pickup_mushroom_powerup.prefab";
                    tag = "Power";
                    break;
            }

            obj = Instantiate((GameObject)(UnityEditor.AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject))));
        	
            obj.transform.position = GetComponent<Rigidbody>().position + Vector3.up;
            obj.gameObject.tag = tag;
            
            if (tag == "Piece") StartCoroutine(coinAnim());
            else {
                obj.AddComponent<MushroomMovement>();
                obj.AddComponent<Rigidbody>();
                obj.AddComponent<CapsuleCollider>();
                isFull = false;
            }

        	
        }
    }
    
    IEnumerator coinAnim(){
        yield return new WaitForSeconds(0.5f);
        Destroy(obj.gameObject);
        if (coins == 0) Destroy(this.gameObject);
    }
}
