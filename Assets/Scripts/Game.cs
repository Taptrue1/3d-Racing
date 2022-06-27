using UnityEngine;
using PathCreation;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PathCreator _pathCreator;
    [Header("Views")]
    [SerializeField] private FuelView _fuelView;
    [SerializeField] private CoinView _coinView;
    [SerializeField] private PathView _pathView;

    private CustomValue _fuel;
    private CustomValue _coins;
    private CustomValue _pathPassed;
    private PathCounter _pathCounter;

    private void Awake()
    {
        _fuel = new CustomValue(1, true, 1, 0);
        _coins = new CustomValue();
        _pathPassed = new CustomValue();
        _pathCounter = new PathCounter(_player.transform, _pathCreator);

        _fuelView.Init(_fuel);
        _coinView.Init(_coins);
        _pathView.Init(_pathPassed);

        _player.Init(_fuel, _coins);
    }

    private void FixedUpdate()
    {
        _pathPassed.SetValue(_pathCounter.GetPassedPath());
    }
}
