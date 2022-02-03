using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField] private GameObject _pauseMenuUI;

  private bool _gameIsPaused = false;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape)) return;
    if (_gameIsPaused)
      Resume();
    else
      Pause();
  }

  public void Pause()
  {
    _pauseMenuUI.SetActive(true);
    PauseGame();
  }

  public void Resume()
  {
    _pauseMenuUI.SetActive(false);
    RunGame();
  }

  public void Menu()
  {
    RunGame();
    SceneManager.LoadScene("Menu");
  }

  public void Restart()
  {
    RunGame();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  private void PauseGame()
  {
    PauseTimeScale();
    _gameIsPaused = true;
  }

  private static void PauseTimeScale()
  {
    Time.timeScale = 0f;
  }

  private void RunGame()
  {
    RunTimeScale();
    _gameIsPaused = false;
  }

  private static void RunTimeScale()
  {
    Time.timeScale = 1f;
  }
}