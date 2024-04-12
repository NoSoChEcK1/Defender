using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private PlayerDie die;
    [SerializeField] private Slider sliderHp;
    [SerializeField] private Kills kills;
    private int hp = 10;
    public static int curHp;
    private void SetHp()
    {
        sliderHp.maxValue = hp;
        sliderHp.value = curHp;
    }
    private void check()
    {
        if (curHp <= 0)
        {
            die.GTlastScene();
        }
    }
    private void Start()
    {
        curHp = 10;
    }
    private void Update()
    {
        check();
        SetHp();
    }
    public static void GetDmg(int dmg)
    {
        curHp -= dmg;
    }
}
