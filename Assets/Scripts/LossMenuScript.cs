using System;
using UnityEngine;
using UnityEngine.UI;

public class LossMenuScript : MonoBehaviour
{
  [SerializeField] private GameObject _lossMenuUI;
  [SerializeField] private Text _scoreTxt;
  [SerializeField] private PlayerStats _playerStat;

  internal void Start()
  {
    _lossMenuUI.SetActive(true);
    Time.timeScale = 0f;
    UpdateScoreLbl();
  }

  private void UpdateScoreLbl()
  {
    _scoreTxt.text = $"Score: {_playerStat.Score}";
  }
}