using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevelButton : MonoBehaviour
{

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
