using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    private int facingDirection = 1;
    private EnemyState enemyState, newState;
    public float attackRange = 2;

    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Chasing) // a fost if(isChasing == true)
        {
            Chase();
        }
        else if(enemyState == EnemyState.Attacking)
        {
            //attack stuff
            rb.linearVelocity= Vector2.zero;
        }
            
    }

    void Chase()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
        }

        else if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerStayr2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warrior_Blue")
        {
            if(player == null) 
            {
                player = collision.transform;
            }
            //isChasing = true; 
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warrior_Blue")
        {
            rb.linearVelocity = Vector2.zero;
            //isChasing = false;
            ChangeState(EnemyState.Idle);

        }
    }

    void ChangeState(EnemyState newstate)
    {   
        //exit the current animation
        if(enemyState == EnemyState.Idle)
            anim.SetBool("isidle", false);
        else if(enemyState == EnemyState.Chasing)
            anim.SetBool("ischasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isattacking", false);

        //update the current state
        enemyState = newstate;

        //update the new animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isidle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("ischasing", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isattacking", true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}