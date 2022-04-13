using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject readyPanel;
    [SerializeField] GameObject onGamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameSuccessPanel;

    private void Update()
    {
        GameStatus gameStatus = Game.Instance.gameStatus;
        readyPanel.SetActive(gameStatus == GameStatus.Ready);
        onGamePanel.SetActive(gameStatus == GameStatus.OnGame);
        gameOverPanel.SetActive(gameStatus == GameStatus.GameOver);
        gameSuccessPanel.SetActive(gameStatus == GameStatus.GameClear);
    }

}
