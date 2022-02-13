using UnityEngine;

public class BallSpeedUpPickUp : PickUpBase
{
  [SerializeField] private float _speedMultiplier;

  protected override void ApplyPickUp()
  {
    Ball ball = FindObjectOfType<Ball>();
    //ball.ChangeSpeed(_speedMultiplier);
  }
}