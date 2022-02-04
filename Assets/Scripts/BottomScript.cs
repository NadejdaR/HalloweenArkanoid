using UnityEngine;

public class BottomScript : MonoBehaviour
{
  [SerializeField] private PlayerStatManager _statManager;
  [SerializeField] private Ball _ball;
  [SerializeField] private LossMenuScript _loss;

  private void OnCollisionEnter2D(Collision2D col)
  {
    _statManager.Life--;
    _statManager.ReduceLife(_statManager.Life);

    if (_statManager.Life == 0)
      _loss.Start();
    else ResetBall();
  }

  private void ResetBall()
  {
    _ball._isStarted = false;
    _ball.Update();
  }
}