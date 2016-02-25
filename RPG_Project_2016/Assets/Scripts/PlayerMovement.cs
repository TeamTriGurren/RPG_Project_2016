using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float speed = .25f;
    public bool isMoving = true;
    public bool isTalking = false;
    public static string region;
    public Vector2 lastMove;

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

   

    private NPC npc;
    public GameController gc;
    public BattleController bc;

    void Awake()
    {
        region = "TestRegion";
    }
    void Start()
    {  
        secondCounter = Random.Range(10, 50);
        anim = GetComponent<Animator>();
        
    }
 
    void Update()
    {
        GameObject npcscript = GameObject.Find("Dialog");
        NPC nScript = npcscript.GetComponent<NPC>();

        isMoving = false;
        calculateBattle();
        if (!inCombat || !isTalking)
        {
            
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                isMoving = true;
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                isMoving = true;
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("isMoving", isMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

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
                secondCounter = Random.Range(5, 50);
                walkCounter = 0;        
                enterCombat();
            } 
    }

    void enterCombat()
    {
        gc.randomizeMonster();
        bc.Start();
        inCombat = true;
        MCamera.SetActive(false);
        CombatCamera.SetActive(true);
      //  Debug.Log("Combat. " + GameController.enemyMonster.Name);
    }


    
}
