using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private float _minYBounds;

    private List<Transform> _allObjects;

    private void Start()
    {
        _allObjects = new List<Transform>();
        var childrenObjects = GetComponentsInChildren<Transform>();

        foreach(var child in childrenObjects)
            _allObjects.Add(child);
    }
    private void FixedUpdate()
    {
        var objectsOutside = FindObjectsOutsideBounds();

        if (objectsOutside != null)
            DestroyAllObjectsOutsideBounds(objectsOutside);
    }

    private void DestroyAllObjectsOutsideBounds(List<Transform> objectsOutside)
    {
        foreach (var obj in objectsOutside)
        {
            _allObjects.Remove(obj);
            Destroy(obj.gameObject);
        }
    }
    private List<Transform> FindObjectsOutsideBounds()
    {
        var objectsOutside = new List<Transform>();

        foreach(var obj in _allObjects)
        {
            if(obj.transform.position.y < _minYBounds)
                objectsOutside.Add(obj);
        }

        return objectsOutside;
    }
}