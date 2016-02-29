using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    public float speed = .25f;
    public bool isMoving = true;
    public bool isTalking;
    public static string region;
    public Vector2 lastMove;
    private bool attacking;
    public float attackTime;
    public float attackTimeCounter;
    Animator anim;
    private Rigidbody2D myRigidbody;

    //Camera shit
    public GameObject MCamera;
	public bool Dialog = false;
   // public BattleController bc;

    void Awake()
    {
        region = "TestRegion";
        if ( player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if ( player != this)
        {
            Destroy(gameObject);
        }
      //  DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {  
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        GameObject npcscript = GameObject.Find("Dialog");
        isMoving = false;


        if (!attacking)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {

                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, myRigidbody.velocity.y);
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                isMoving = true;
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * speed);
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                isMoving = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attacking", true);
            }

        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attacking", false);
        }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("isMoving", isMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

            if (Dialog) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Debug.Log ("Space Worked");
				}
			}
        
    }


    private void OnTriggerEnter2D(Collider2D Other)
    {
		
        if (Other.gameObject.tag == "BattleArea")
        {
			
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
}
