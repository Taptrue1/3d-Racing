using UnityEngine;
using PathCreation;

public class PathCounter
{
    private Transform _player;
    private PathCreator _path;
    private float _lastPathPassed;
    private Vector3 _startPoint;

    public PathCounter(Transform player, PathCreator path)
    {
        _player = player;
        _path = path;
        _startPoint = _path.path.GetClosestPointOnPath(player.position);
    }

    public float GetPassedPath()
    {
        var currentPoint = _path.path.GetClosestPointOnPath(_player.position);
        var distanceOffset = _path.path.GetClosestDistanceAlongPath(_startPoint);
        var currentDistance = _path.path.GetClosestDistanceAlongPath(currentPoint);
        var passedDistance = currentDistance - distanceOffset;

        return passedDistance;
    }
    public float GetPassedPath1()
    {
        var targetPoint = _path.path.GetClosestPointOnPath(_player.position);
        var distance = _path.path.GetClosestDistanceAlongPath(targetPoint);
        var distancePassed = distance - _lastPathPassed;

        _lastPathPassed = distance;

        return distance;
    }
}
