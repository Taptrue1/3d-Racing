﻿using UnityEngine;
using UnityEngine.UI;

public class FuelView : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;

    public void Init(CustomValue fuel)
    {
        fuel.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        var resultValue = Mathf.Ceil(value);
        _progressBar.value = resultValue;
    }
}