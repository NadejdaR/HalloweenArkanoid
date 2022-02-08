using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField] private GameObject _pauseMenuUI;
  [SerializeField] private GameObject _settingMenuUI;

  public static bool GameIsPaused { get; private set; }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape)) return;
    if (GameIsPaused)
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

  public void Settings()
  {
    _pauseMenuUI.SetActive(false);
    _settingMenuUI.SetActive(true);
  }

  public void CloseSettings()
  {
    _settingMenuUI.SetActive(false);
    _pauseMenuUI.SetActive(true);
  }

  public void NextLvl()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  private void PauseGame()
  {
    PauseTimeScale();
    GameIsPaused = true;
  }

  private static void PauseTimeScale()
  {
    Time.timeScale = 0f;
  }

  private void RunGame()
  {
    RunTimeScale();
    GameIsPaused = false;
  }

  private static void RunTimeScale()
  {
    Time.timeScale = 1f;
  }
}