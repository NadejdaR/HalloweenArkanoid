using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  [Header("Common")]
  [SerializeField] private PlayerStats _playerStats;

  [Header("WinPanel")] 
  [SerializeField] private GameObject _winMenuUI;
  [SerializeField] private Text _winTxtScore;

  [Header("LossPanel")]
  [SerializeField] private GameObject _lossMenuUI;
  [SerializeField] private Text _lossTxtScore;
  
  [Header("Pause")]
  [SerializeField] private GameObject _pauseMenuUI;
  
  [Header("Setting")]
  [SerializeField] private GameObject _settingMenuUI;

  private static bool _isGamePaused = false;
  public static bool GameIsPaused => _isGamePaused;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape)) return;
    if (GameIsPaused)
      ResumeBtn();
    else
      PauseBtn();
  }
  
  public void ExitBtn()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }
  
  public void MenuBtn()
  {
    RunGame();
    SceneManager.LoadScene("Menu");
  }
  
  public void PauseBtn()
  {
    _pauseMenuUI.SetActive(true);
    PauseGame();
  }

  public void ResumeBtn()
  {
    _pauseMenuUI.SetActive(false);
    RunGame();
  }
  
  public void RestartBtn()
  {
    RunGame();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void SettingsBtn()
  {
    _pauseMenuUI.SetActive(false);
    _settingMenuUI.SetActive(true);
  }

  public void AcceptSettingsBtn()
  {
    _settingMenuUI.SetActive(false);
    _pauseMenuUI.SetActive(true);
  }

  public void NextLvlBtn()
  {
    RunGame();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  
  public void WinGamePanel()
  {
    _winMenuUI.SetActive(true);
    FinGame(_winTxtScore);
  }
  
  public void LossGamePanel()
  {
    _lossMenuUI.SetActive(true);
    FinGame(_lossTxtScore);
  }

  private void FinGame(Text txt)
  {
    PauseGame();
    txt.text = $"Score: {_playerStats.Score}";
  }
  
  private void PauseGame()
  {
    PauseTimeScale();
    _isGamePaused = true;
  }

  private static void PauseTimeScale()
  {
    Time.timeScale = 0f;
  }

  private void RunGame()
  {
    RunTimeScale();
    _isGamePaused = false;
  }

  private static void RunTimeScale()
  {
    Time.timeScale = 1f;
  }
}