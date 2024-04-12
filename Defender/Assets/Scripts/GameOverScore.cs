using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textKils;
    public void SetScore()
    {
        textKils.text = Kills.countKills.ToString();
    }
    private void Start()
    {
        SetScore();
    }
}
