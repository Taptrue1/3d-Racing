using UnityEngine;
using PathCreation;

public class PathCounter
{
    private Transform _target;
    private PathCreator _path;
    private float _lastPathPassed;

    public PathCounter(Transform target, PathCreator path)
    {
        _target = target;
        _path = path;
    }

    public float GetPassedPath()
    {
        var targetPoint = _path.path.GetClosestPointOnPath(_target.position);
        var distance = _path.path.GetClosestDistanceAlongPath(targetPoint);
        var distancePassed = distance - _lastPathPassed;

        _lastPathPassed = distance;

        return distancePassed;
    }
}
