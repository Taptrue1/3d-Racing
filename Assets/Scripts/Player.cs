using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.01f, 0.1f)] private float _fuelReduceSpeed;

    private CustomValue _fuel;
    private CustomValue _coins;

    private void Update()
    {
        ReduceFuel();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
            _coins.Add(1);
        else if(other.TryGetComponent(out Fuel fuel))
            _fuel.SetValue(1);
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