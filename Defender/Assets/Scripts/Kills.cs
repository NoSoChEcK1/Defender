using TMPro;
using UnityEngine;

public class Kills : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textKils;
    public static int countKills;
    void Update()
    {
        textKils.SetText(countKills.ToString());
    }
    private void Start()
    {
        countKills = 0;
    }
}
