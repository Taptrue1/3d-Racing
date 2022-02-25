using System.Collections;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class ObjectSpawner : MonoBehaviour
{
    [ValueDropdown("GetAllPrefabs", AppendNextDrawer = true)]
    [ShowInInspector] private GameObject _spawnObject;

    private void Start() => Instantiate(_spawnObject, transform, false);

    private IEnumerable GetAllPrefabs()
    {
        return UnityEditor.AssetDatabase.FindAssets("t:MonoBehaviour")
            .Select(x => UnityEditor.AssetDatabase.GUIDFromAssetPath(x))
            .Select(x => new ValueDropdownItem(x.ToString(), UnityEditor.AssetDatabase.LoadAssetAtPath<MonoBehaviour>(x.ToString())));
    }
}
