using UnityEngine;

public class GameOverLoader : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true); //turns on GameOver UI
    }
}
