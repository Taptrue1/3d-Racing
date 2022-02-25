using UnityEngine;
using PathCreation;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _sidePositionOffset;
    [SerializeField] private float _minYBound;

    private void Awake()
    {
        _player.FuelIsOver += OnLose;
        _player.FinishPassed += OnWin;
    }
    private void FixedUpdate()
    {
        CheckPlayerInBounds();
    }

    private void OnWin()
    {
        Debug.Log("You win");
    }
    private void OnLose()
    {
        Time.timeScale = 0;
        Debug.Log("You lose");
    }
    private void CheckPlayerInBounds()
    {
        var playerPosition = _player.transform.position;
        var point = _pathCreator.path.GetClosestPointOnPath(playerPosition);
        var leftBound = point.z - _sidePositionOffset;
        var rightBound = point.z + _sidePositionOffset;
        var isOutLeftBound = playerPosition.z < leftBound;
        var isOutRightBound = playerPosition.z > rightBound;
        var isOutDownBound = playerPosition.y < _minYBound;

        if (isOutLeftBound || isOutRightBound || isOutDownBound)
            OnLose();
    }
}