using UnityEngine;

public class LevelManager : MonoBehaviour
{
  [SerializeField] private GameObject _winMenuUI;

  private int _blockCount;

  private void OnEnable()
  {
    Block.OnCreated += AddBlock;
    Block.OnDestroyed += RemoveBlock;
  }

  private void OnDisable()
  {
    Block.OnCreated -= AddBlock;
    Block.OnDestroyed -= RemoveBlock;
  }

  private void AddBlock()
  {
    _blockCount++;
  }

  private void GameWin()
  {
    _winMenuUI.SetActive(true);
  }

  private void RemoveBlock(Block block)
  {
    _blockCount--;
    if (_blockCount <= 0)
    {
      GameWin();
    }
  }
}