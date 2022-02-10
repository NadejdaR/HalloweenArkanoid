using UnityEngine;

public class BottomScript : MonoBehaviour
{
  [SerializeField] private PlayerStatManager _statManager;
  [SerializeField] private Ball _ball;
  [SerializeField] private UIManager _loss;

  private void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.CompareTag(Tags.Ball))
    {
      _statManager.Life--;
      _statManager.ReduceLife(_statManager.Life);
      ResetBall();
    }

    if (_statManager.Life == 0)
      _loss.LossGamePanel();
  }

  private void ResetBall()
  {
    _ball._isStarted = false;
    _ball.Update();
  }
}