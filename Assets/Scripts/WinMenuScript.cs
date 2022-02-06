using UnityEngine;

public class WinMenuScript : MonoBehaviour
{
  [SerializeField]private PlayerStatManager _statManager;

  private void Start()
  {
    Time.timeScale = 0f;
    _statManager.UpdateScoreLbl();
  }
}