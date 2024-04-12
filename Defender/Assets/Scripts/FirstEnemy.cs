using UnityEngine;

public class FirstEnemy : EnemyMove
{
    Rigidbody2D rb;
    public override bool CheckDist()
    {
        if (Mathf.Abs(transform.position.x - playerX) > range) return true;
        else return false;
    }
    protected override void Move()
    {
        if (CheckDist())
        {
            if (rb.position.x > 0)
            {
                rb.velocity = new Vector2(-speed, 0);
                animator.SetFloat("Run", 1);
            }
            else if (rb.position.x < 0)
            {
                rb.velocity = new Vector2(speed, 0);
                animator.SetFloat("Run", 1);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("Run", -1);
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerX = 0;
        range = 1.2f;
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
}