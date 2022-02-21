using UnityEngine;
using PathCreation;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private string _textFormat;

    float _lastScore;

    private void Update()
    {
        var targetPoint = _pathCreator.path.GetClosestPointOnPath(_target.position);
        var distance = _pathCreator.path.GetClosestDistanceAlongPath(targetPoint);

        if(distance > _lastScore)
        {
            _lastScore = distance;
            _textField.text = string.Format(_textFormat, Mathf.Ceil(distance));
        }
    }
}
