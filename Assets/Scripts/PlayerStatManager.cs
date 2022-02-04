using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
  [SerializeField] private PlayerStats _playerStat;
  [SerializeField] private Text _scoreTxt;

  public List<Image> LifeImg;
  [NonSerialized] public int Life;

  private void OnEnable()
  {
    _playerStat.OnScoreUpdated += UpdateScoreLbl;
  }

  private void OnDisable()
  {
    _playerStat.OnScoreUpdated -= UpdateScoreLbl;
  }

  private void Start()
  {
    Life = LifeImg.Count;
    _playerStat.ResetScore();
    UpdateScoreLbl();
  }

  public void UpdateScoreLbl()
  {
    _scoreTxt.text = $"Score: {_playerStat.Score}";
  }

  public void ReduceLife(int remainingLife)
  {
    LifeImg[remainingLife].gameObject.SetActive(false);
  }
}