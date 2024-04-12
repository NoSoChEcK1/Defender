using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartG : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
