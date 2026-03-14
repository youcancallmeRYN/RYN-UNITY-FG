using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuLoader : MonoBehaviour
{
    public static MainMenuLoader Instance;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
        Destroy(gameObject); // "gameObject" is for this script, if using "GameObject" it will use Unity's component of "GamObject".
        }
    }

    public void LoadScene (string sceneName)
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(sceneName);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); //closes game
        #endif
    }



}
