using UnityEngine;
using DG.Tweening;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float _animationDuration;

    private Tween _moveTween;

    private void Start()
    {
        Animate();
    }
    private void OnTriggerEnter(Collider other)
    {
        _moveTween.Kill();
        Destroy(gameObject);
    }

    private void Animate()
    {
        var startPosition = transform.position;
        var moveTween = DOTween.Sequence();

        moveTween.Append(transform.DOMoveY(startPosition.y + 1, _animationDuration).SetEase(Ease.InOutSine));
        moveTween.Append(transform.DOMoveY(startPosition.y, _animationDuration).SetEase(Ease.InOutSine));
        moveTween.SetLoops(-1);

        _moveTween = moveTween;
    }
}
