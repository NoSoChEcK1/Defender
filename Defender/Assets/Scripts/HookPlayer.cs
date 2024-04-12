using System.Collections;
using UnityEngine;

public class HookPlayer : MonoBehaviour
{
    AudioSource audioS;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }
    public IEnumerator Hit(float X)
    {
        rb.MovePosition(new Vector2(X,transform.position.y)); 
        yield return new WaitForSeconds(0.1f);
        rb.MovePosition(new Vector2(0, transform.position.y));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audioS.Play();
            EnemyLogic enemy = collision.GetComponent<EnemyLogic>();
            StartCoroutine(enemy.GetDmg(1));
        }
    }
}
