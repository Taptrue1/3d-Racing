using System;

public class CustomValue
{
    public Action<float> ValueChanged;
    public float Value => _value;

    private float _value;
    private bool _isRange;
    private float _maxValue;
    private float _minValue;

    public CustomValue(float startValue = 0, bool isRange = false, float maxValue = 0, float minValue = 0)
    {
        _value = startValue;
        _isRange = isRange;
        _maxValue = maxValue;
        _minValue = minValue;
    }

    public void Add(float value)
    {
        if (IsLessThanZero(value)) 
            return;

        _value += value;

        if (_isRange)
            _value = UnityEngine.Mathf.Clamp(_value, _minValue, _maxValue);

        ValueChanged?.Invoke(_value);
    }
    public void Subtract(float value)
    {
        if (IsLessThanZero(value)) 
            return;

        _value -= value;

        if (_isRange)
            _value = UnityEngine.Mathf.Clamp(_value, _minValue, _maxValue);

        ValueChanged?.Invoke(value);
    }
    public void SetValue(float value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
    }
    public void SetMaxValue()
    {
        if(_isRange)
            _value = _maxValue;
    }
    public void SetMinValue()
    {
        if(_isRange)
            _value = _minValue;
    }

    private bool IsLessThanZero(float value)
    {
        if (value < 0)
            return true;
        
        return false;
    }
}