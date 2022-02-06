using UnityEngine;

public class LossMenuScript : MonoBehaviour
{
  [SerializeField] private GameObject _lossMenuUI;

  private PlayerStatManager _statManager;

  internal void Start()
  {
    _lossMenuUI.SetActive(true);
    Time.timeScale = 0f;
    _statManager.UpdateScoreLbl();
  }
}