using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody2D rigidbody2d;
    public bool isGrounded;
    public bool activelyJumping;
    public float horizontal;
    public bool canMove = true;
    public AudioSource walkGrass;
    public AudioSource walkIce;
    public AudioSource walkMetal;
    public bool isPlaying;

    public AudioSource jump;

    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        if((horizontal > 0 || horizontal < 0) && isGrounded && !isPlaying && (currentScene == "GroundOne" || currentScene == "GroundTwo" || currentScene == "GroundThree" || currentScene == "Ship" || currentScene == "Tutorial"))
        {
            walkGrass.Play();
            isPlaying = true;
        }
        else if(horizontal == 0 || !isGrounded)
        {
            walkGrass.Stop();
            isPlaying = false;
        }

        if ((horizontal > 0 || horizontal < 0) && isGrounded && !isPlaying && (currentScene == "IceOne" || currentScene == "IceTwo" || currentScene == "IceThree"))
        {
            walkIce.Play();
            isPlaying = true;
        }
        else if (horizontal == 0 || !isGrounded)
        {
            walkIce.Stop();
            isPlaying = false;
        }

        if ((horizontal > 0 || horizontal < 0) && isGrounded && !isPlaying && (currentScene == "MetalOne" || currentScene == "MetalTwo" || currentScene == "MetalThree"))
        {
            walkMetal.Play();
            isPlaying = true;
        }
        else if (horizontal == 0 || !isGrounded)
        {
            walkMetal.Stop();
            isPlaying = false;
        }

        if ((horizontal < 0 && transform.localScale.x > 0 || horizontal > 0 && transform.localScale.x < 0 )&& canMove)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        //Debug.Log(rigidbody2d.velocity);
        if (horizontal != 0 &&canMove)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (canMove)
        {
                transform.position = new Vector2(transform.position.x + horizontal * speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && canMove)
            {
                anim.SetBool("isJumpingUp", true);
                isGrounded = false;
                rigidbody2d.velocity = new Vector2(0, 25f);
                activelyJumping = true;
                jump.Play();
            }
        }

        if (0 > rigidbody2d.velocity.y && activelyJumping)
        {
            anim.SetBool("isJumpingDown", true);
            anim.SetBool("isJumpingUp", false);
        }
        else if(0 < rigidbody2d.velocity.y && activelyJumping)
        {
            anim.SetBool("isJumpingUp", true);
            anim.SetBool("isJumpingDown", false);
        }

        if (isGrounded)
        {
            anim.SetBool("isJumpingUp", false);
            anim.SetBool("isJumpingDown", false);
        }
        //Debug.Log(rigidbody2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            anim.SetBool("isJumpingUp", false);
            anim.SetBool("isJumpingDown", false);
            isGrounded = true;
            activelyJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            anim.SetBool("isJumpingUp", false);
            anim.SetBool("isJumpingDown", false);
            isGrounded = true;
            activelyJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            activelyJumping = true;
            isGrounded = false;
            anim.SetBool("isJumpingDown", true);
        }
    }
}
