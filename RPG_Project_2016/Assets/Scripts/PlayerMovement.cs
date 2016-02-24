using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float speed = .25f;
    public bool isMoving = true;
    public bool isTalking = false;
    public static string region;

    Animator anim;
    // Waling Stuff
    int walkCounter;
    int secondCounter;
    bool inCombat;
    public static int Direction = 1 ;

    //Camera shit
    public GameObject MCamera;
    public GameObject CombatCamera;

	public bool Dialog = false;

    public float x, y;

    private NPC npc;
    public GameController gc;

    void Awake()
    {
        region = "TestRegion";
    }
    void Start()
    {  
        secondCounter = Random.Range(10, 75);
        anim = GetComponent<Animator>();
        
    }
 
    void Update()
    {
        GameObject npcscript = GameObject.Find("Dialog");
        NPC nScript = npcscript.GetComponent<NPC>();
        x = transform.position.x;
        y = transform.position.y;

        if (isMoving)
            anim.SetTrigger("isMoving");
        if (!inCombat || !isTalking)
        {
            if (!Input.anyKey)
            {
                isMoving = false;
                anim.ResetTrigger("isMoving");
                
            }
            if (Input.GetKey("w"))
            {
                isMoving = true;
                calculateBattle();
                anim.SetInteger("Direction", 1);
                GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
                Direction = 1;
            }
            if (Input.GetKey("s"))
            {
                calculateBattle();
                anim.SetInteger("Direction", 3); 
                isMoving = true;        
                GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
                Direction =3;
            }
            if (Input.GetKey("a"))
            {
                anim.SetInteger("Direction", 4);
                calculateBattle();   
                isMoving = true;
                GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
                Direction=4;
            }
            if (Input.GetKey("d"))
            {
                anim.SetInteger("Direction", 2);
                calculateBattle();         
                isMoving = true;
                GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
                Direction = 2;
            }
			if (Dialog) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Debug.Log ("Space Worked");
                    nScript.Action();
				}
			}
        }
    }


    private void OnTriggerEnter2D(Collider2D Other)
    {
		
        if (Other.gameObject.tag == "BattleArea")
        {
			Debug.Log ("Battle Area.. Combat in.." + (secondCounter - walkCounter));
            walkCounter++;
        }
		if (Other.gameObject.tag == "Dialog") {
			Debug.Log ("In Action Range");
			//NPC.Action ();
			Dialog = true;
		}
    }

	private void OnTriggerExit2D(Collider2D Other)
	{
		if (Other.gameObject.tag == "Dialog") {
			Debug.Log ("Leave Chat range");
			//NPC.Action ();
			Dialog = false;
		}
	}

    void calculateBattle()
    { 
            if (walkCounter >= secondCounter)
            {
                secondCounter = Random.Range(5, 75);
                walkCounter = 0;        
                enterCombat();
            } 
    }

    void enterCombat()
    {
        gc.randomizeMonster();
        inCombat = true;
        MCamera.SetActive(false);
        CombatCamera.SetActive(true);
      //  Debug.Log("Combat. " + GameController.enemyMonster.Name);
    }


    
}
