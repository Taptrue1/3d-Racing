using UnityEngine;
using PathCreation;
using TMPro;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _sidePositionOffset;
    [SerializeField] private float _minYBound;
    [SerializeField] private TextMeshProUGUI _gameResultTextField;

    private void Awake()
    {
        _gameResultTextField.text = "";

        _player.FuelIsOver += OnLose;
        _player.FinishPassed += OnWin;
    }
    private void FixedUpdate()
    {
        CheckPlayerInBounds();
    }

    private void OnWin()
    {
        Time.timeScale = 0;
        _gameResultTextField.text = "YOU WIN!";
    }
    private void OnLose()
    {
        Time.timeScale = 0;
        _gameResultTextField.text = "YOU LOSE!";
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