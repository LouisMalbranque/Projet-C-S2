using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script de gestion des mouvements de mario et de ses interractions avec l'environement

public class MovementMario : MonoBehaviour
{
    // Update is called once per frame
    
    public float speed = 0.08F;
    public float jumpForce = 5;
    public short allowJump = 1;
    public Vector3 initialPosition = new Vector3(-49,1,0);
    public static int initialHealth = 5; 

    private int nombredewin = 0;
    public static int coin = 0;
    private int powerUp = 0;
    private int health = initialHealth;
    private GameObject mushroomPowerUp;
    private bool gameOver = false;

    void FixedUpdate()
    {   
        if (health > 0){
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal != 0){
                if (moveHorizontal > 0) transform.eulerAngles = new Vector3(0, 90, 0);
                else transform.eulerAngles = new Vector3(0, -90, 0);
                GetComponent<Animation>().Play("run");
            }else GetComponent<Animation>().Play("idle");


            if (Input.GetButtonDown("Jump") && allowJump != 0){
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                allowJump -= 1;
            }
            Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
            GetComponent<Rigidbody>().position += movement*speed;

            //transform.eulerAngles = new Vector3(0,90,0);
            if (GetComponent<Rigidbody>().position.y < 0){
                gameOver=true;
                restart();   
            }
        }
        if (GetComponent<Rigidbody>().position.x>90 && gameOver == false){
            gameOver = true;
            nombredewin++;
            StartCoroutine(win());
        }
    }
    void OnCollisionEnter(Collision col)
    {	
        if(col.gameObject.tag == "Sol")
        {
        	GetComponent<Animation>().Play("idle");
            allowJump = 2;
        }
        if(col.gameObject.tag == "Piece")
        {
        	Destroy(col.gameObject);
            coin ++;
        }
        if(col.gameObject.tag == "Power")
        {
            transform.localScale += new Vector3(0.2f,0.2f,0.2f);
            Destroy(col.gameObject);
            powerUp ++;
        }
        if(col.gameObject.tag == "Life")
        {
            Destroy(col.gameObject);
            health ++;
        }
        if(col.gameObject.tag == "enemy"){
            Destroy(col.gameObject);
            if (powerUp>0){
                transform.localScale -= new Vector3(0.2f,0.2f,0.2f);
                powerUp--;
            }
            else{
                health --; 
            } 
            if (health == 0){
                StartCoroutine(die());
            }
        }
        if (col.gameObject.tag == "Wall"){
            allowJump=2;
        }
    }

    void OnCollisionExit(Collision col)
    {
    	if(col.gameObject.name == "Sol")
        {
            GetComponent<Animation>().Play("jump_1");
        }
    }

    void OnGUI(){
        GUI.Box(new Rect(0, 0, 100, 80), "");                                       // gui box for background   
        GUI.Label(new Rect(10, 5, 100, 100), "Health: " + health);                      // gui label to show coin and current value
        GUI.Label(new Rect(10, 20, 100, 100), "Coins: " + coin);
        GUI.Label(new Rect(10, 35, 100, 100), "Power: " + powerUp);
        GUI.Label(new Rect(10, 50, 100, 100), "Win: " + nombredewin);
    }


    IEnumerator die(){
        transform.eulerAngles = new Vector3(0,180,0);
        yield return new WaitForSeconds(0.5f);

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().position += new Vector3(0,0,-1);
        restart();
    }
    void restart(){
        gameOver=false;
        GetComponent<Rigidbody>().position = initialPosition;
        health = initialHealth;
        createCoin(-42, 2, 0);
        createCoin(-40, 2, 0);
        createCoin(-37, 3, 0);
        createCoin(-34, 4, 0);
    }
    void createCoin(int posx, int posy, int posz){
        GameObject piece = Instantiate((GameObject)(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Mario/Prefabs/Scene Pickups/prefab_pickup_coin.prefab", typeof(GameObject))));
        piece.transform.position = new Vector3(posx, posy, posz);
        piece.AddComponent<BoxCollider>();
        piece.gameObject.tag= "Piece";
        piece.transform.localScale = new Vector3(1,1,1);
    }

    IEnumerator win(){
        yield return new WaitForSeconds(5);
        restart();
    }
}
