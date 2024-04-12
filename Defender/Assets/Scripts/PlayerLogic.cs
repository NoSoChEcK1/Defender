using System.Collections;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]public Animator animator;
    [SerializeField] public HookPlayer hook;
    IEnumerator TimeBeforStay()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetFloat("HorizontalHit", -1f);
    }
    void HitEnemy()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            TurnRight();
            animator.SetFloat("HorizontalHit", 1f);
            StartCoroutine(hook.Hit(1f));
            StartCoroutine(TimeBeforStay());
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TurnLeft();
            animator.SetFloat("HorizontalHit", 1f);
            StartCoroutine(hook.Hit(-1f));
            StartCoroutine(TimeBeforStay());
        }
    }
    private void TurnLeft()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -1f;
        transform.localScale = scale;
    }

    private void TurnRight()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    private void Update()
    {
        HitEnemy();
    }
}
