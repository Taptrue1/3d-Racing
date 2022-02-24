using UnityEngine;
using TMPro;

public class PathView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private string _textFormat;

    public void Init(CustomValue pathPassed)
    {
        pathPassed.ValueChanged = OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        var resultValue = Mathf.Ceil(value);
        _textField.text = string.Format(_textFormat, resultValue);
    }
}