using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private float _minZBounds;

    private GameObject[] _objects;

    private void Start()
    {
        _objects = GetComponentsInChildren<GameObject>();
    }
    private void FixedUpdate()
    {
        var objectsOutside = FindObjectsOutsideBounds();

        if (objectsOutside != null)
            DeleteAllObjectsOutsideBounds(objectsOutside);
    }

    private void DeleteAllObjectsOutsideBounds(List<GameObject> objectsOutside)
    {
        foreach(var obj in objectsOutside)
            Destroy(obj);
    }
    private List<GameObject> FindObjectsOutsideBounds()
    {
        var objectsOutside = new List<GameObject>();

        foreach(var obj in _objects)
        {
            if(obj.transform.position.z < _minZBounds)
                objectsOutside.Add(obj);
        }

        return objectsOutside;
    }
}