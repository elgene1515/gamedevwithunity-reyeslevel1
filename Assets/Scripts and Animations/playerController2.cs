using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpforce;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public GameObject myGameObject;
    public GameObject bgm;
    public GameObject bgmwin;
    public GameObject portalrestart;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    public Animator animator;

    void Start() // Start is called before the first frame update
    {

    }
    void Awake()//reads the code if the assets is open
    {
        rb=GetComponent<Rigidbody2D>();
    }

    
    void Update()// Update is called once per frame
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if(isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        else animator.SetBool("isJumping", true);

        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            animator.SetTrigger("Attack");
        }
        //move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        
        //change Speed of animator
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpforce));
        }
        isJumping =  false;



        //get input
        moveDirection = Input.GetAxis("Horizontal"); //a=-1 d=1

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }



        //flip
        if(moveDirection > 0 && !facingRight)
        {
            FlipChar();
        }
        else if (moveDirection <0 && facingRight)
        {
            FlipChar();
        }
    }

    private void FlipChar()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals ("Respawn"))
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collider.gameObject.tag.Equals ("Finish"))
        {
            bgm.SetActive(false);
            bgmwin.SetActive(true);
            myGameObject.SetActive(true);
            portalrestart.SetActive(true);
            Debug.Log("Player Succeed");
        }
        if (collider.gameObject.tag.Equals ("restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}   
