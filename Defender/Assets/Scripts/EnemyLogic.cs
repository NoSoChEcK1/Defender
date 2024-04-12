using System.Collections;
using UnityEngine;

public  class EnemyLogic : MonoBehaviour
{
    private EnemyMove enemy;
    private Animator animator;
    private int hp;
    AudioSource audioS;
    public IEnumerator GetDmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            animator.SetBool("Death", true);
            yield return new WaitForSeconds(0.5f);
            destroy();
            Spawner.killEnemy();
            ++Kills.countKills;
        }
    }
    protected IEnumerator Hit()
    {
        animator.SetBool("IsAtack", true);
        audioS.Play();
        yield return new WaitForSeconds(1f);
        Health.GetDmg(1);
    }
    private IEnumerator TimeThit()
    {
        yield return new WaitForSeconds(1f);
        if (!enemy.CheckDist())
        {
            StartCoroutine(Hit());
        }
        StartCoroutine(TimeThit());
    }
    private void Start()
    {
        hp = 4;
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyMove>();
        audioS = GetComponent<AudioSource>();
        StartCoroutine(TimeThit());
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}
