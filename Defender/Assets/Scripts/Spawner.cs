using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int leftS=-15, rightS=15,maxEnemy=3,varEnemy=3;
    private float intervalSpawn = 2;
    private static int countEnemy = 0;
    [SerializeField] private GameObject FirEnemy;
    [SerializeField] private GameObject SecEnemy;
    [SerializeField] private GameObject ThirdEnemy;
    private void Spawn()
    {
        if (countEnemy < maxEnemy)
        {
            int randEnemy = Random.Range(0, varEnemy);
            int randSide = Random.Range(0, 2);
            randSide = (randSide == 0) ? leftS:rightS; 

            GameObject enemy;
            if(randEnemy == 0)
            {
                enemy = GameObject.Instantiate(FirEnemy, new Vector2(randSide, -4f), Quaternion.identity);
            }
            else if(randEnemy == 1)
            {
                enemy = GameObject.Instantiate(SecEnemy, new Vector2(randSide, -4f), Quaternion.identity);
            }
            else
            {
                enemy = GameObject.Instantiate(ThirdEnemy, new Vector2(randSide, -4f), Quaternion.identity);
            }
            if (randSide >0)
            {
                TurnRight(enemy);
            }
            else if(randSide <0)
            {
                TurnLeft(enemy);
            }
            ++countEnemy;
        }
    }
    private void TurnLeft(GameObject gb)
    {
        Vector3 scale = gb.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -1f;
        gb.transform.localScale = scale;
    }

    private void TurnRight(GameObject gb)
    {
        Vector3 scale = gb.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        gb.transform.localScale = scale;
    }
    public static void killEnemy()
    {
        --countEnemy;
    }
    private IEnumerator TimeTSpawn()
    {
        yield return new WaitForSeconds(intervalSpawn);
        Spawn();
        StartCoroutine(TimeTSpawn());
    }
    private void Start()
    {
       countEnemy = 0;
       StartCoroutine(TimeTSpawn());
    }
}
