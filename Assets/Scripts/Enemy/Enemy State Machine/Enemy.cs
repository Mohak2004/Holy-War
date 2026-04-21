using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyData;
    public Transform player;
    public Rigidbody2D rb;
    public Collider2D col;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    EnemyStateMachine enemyStateMachine;

    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;

    public Vector2 moveDir;

    public float currentHealth;
    public float moveSpeed, attackRange, knockbackTimer, cooldownTimer;
    public bool isChasing, isAttacking, isAttackingLeft, isAttackingRight, isKnockback;

    public void Init(EnemySO e)
    {
        isChasing = true;
        isAttackingLeft = false;
        isAttackingRight = false;
        isKnockback = false;

        moveSpeed = e.enemySpeed;
        attackRange = e.attackRange;
        currentHealth = e.enemyHealth;
        knockbackTimer = 0.5f;
        cooldownTimer = e.cooldownTime;

        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        if (col == null)
            Debug.Log("No Collider!!");
    }

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMachine();
        chaseState = new EnemyChaseState(this, enemyStateMachine);
        attackState = new EnemyAttackState(this, enemyStateMachine);

        Init(enemyData);
    }

    private void Start()
    {
        enemyStateMachine.Initialize(chaseState);
    }

    private void FixedUpdate()
    {
        moveDir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y).normalized;
        cooldownTimer -= Time.deltaTime;

        if (isKnockback)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer < 0)
            {
                knockbackTimer = 0.5f;
                isKnockback = false;
            }
        }

        enemyStateMachine.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemyStateMachine.currentState.OnCollisionEnter(collision);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeKnockback(float knowkback)
    {
        isKnockback = true;
        rb.AddForce(moveDir * -1 * knowkback, ForceMode2D.Impulse);
    }

    public void GoToChaseState()
    {
        enemyStateMachine.ChangeState(chaseState);
    }
}
