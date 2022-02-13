using UnityEngine;

public class ScorePickUp : PickUpBase
{
  [SerializeField] private int _scoreToAdd;
  protected override void ApplyPickUp()
  {
    //PlayerStatManager.AddScore(_scoreToAdd);
  }
}