using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
  [SerializeField] private PlayerStats _playerStat;
  [SerializeField] private Text _scoreTxt;

  [Header("Life")]
  public int Life;
  [SerializeField] private GameObject _lifeImg;
  [SerializeField] private Transform _livesParent;

  private readonly List<GameObject> _currentLivesImg = new List<GameObject>();

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
    InstantiateLives();
    _playerStat.ResetScore();
    UpdateScoreLbl();
  }

  public void ReduceLife(int remainingLife)
  {
    _currentLivesImg[remainingLife].SetActive(false);
  }

  private void InstantiateLives()
  {
    for (int i=0; i < Life; i++)
    {
      GameObject Live = Instantiate(_lifeImg, _livesParent);
      _currentLivesImg.Add(Live);
    }
  }

  private void UpdateScoreLbl()
  {
    _scoreTxt.text = $"Score: {_playerStat.Score}";
  }
}