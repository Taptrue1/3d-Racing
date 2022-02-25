using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action FinishPassed;
    public Action FuelIsOver;

    [SerializeField] private RearWheelDrive _rearWheelDrive;
    [SerializeField, Range(0.01f, 0.1f)] private float _fuelReduceSpeed;

    private CustomValue _fuel;
    private CustomValue _coins;

    private void FixedUpdate()
    {
        ReduceFuel();
        _rearWheelDrive.SetFuelValue(_fuel.Value);
        
        if(_fuel.Value == 0)
            FuelIsOver?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _coins.Add(1);
            coin.Destroy();
        }
        else if (other.TryGetComponent(out Fuel fuel))
        {
            _fuel.SetValue(1);
            fuel.Destroy();
        }
        else if (other.TryGetComponent(out Finish finish))
            FinishPassed?.Invoke();
    }

    public void Init(CustomValue fuel, CustomValue coins)
    {
        _fuel = fuel;
        _coins = coins;
    }

    private void ReduceFuel()
    {
        var canReduce = _fuel.Value > 0;
        if(canReduce)
            _fuel.Subtract(_fuelReduceSpeed * Time.deltaTime);
    }
}