using UnityEngine;

public abstract class EnemyMove : MonoBehaviour
{
    protected Animator animator;
    protected int speed;
    protected float playerX;
    protected float range;
    public abstract bool CheckDist();
    protected abstract void Move();
}
