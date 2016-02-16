using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = .25f;
    public bool isMoving = true;
    public static bool isTalking = false;
    public static int region = 0; 

    Animator anim;
    // Waling Stuff
    int walkCounter;
    int secondCounter;
    bool inCombat;
    public static int Direction = 1 ;

    //Camera shit
    public GameObject MCamera;
    public GameObject CombatCamera;

    void Start()
    {  
        secondCounter = Random.Range(10, 75);
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        if (isMoving)
            anim.SetTrigger("isMoving");
       
        if (!inCombat && !isTalking)
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

        }
    }


    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "BattleArea")
        {
            walkCounter++;
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
        inCombat = true;
        MCamera.SetActive(false);
        CombatCamera.SetActive(true);
        Debug.Log("Combat.");
    }


    //Animator anim;
    //public float maxSpeed = 10f;
    //bool facingRight = true;
    //bool facingUp = true;

    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{

    //    float move = Input.GetAxis("Horizontal");
    //    float moveUp = Input.GetAxis("Vertical");

    //    anim.SetFloat("input_x", Mathf.Abs(move));
    //    anim.SetFloat("input_y", Mathf.Abs(moveUp));

    //    GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    //    if (move > 0 && !facingRight)
    //        Flip();
    //    else if (move < 0 && facingRight)
    //        Flip();

    //}

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}
}
