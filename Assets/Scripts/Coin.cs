using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _animationDuration;

    private Tween _rotateTween;

    private void Start()
    {
        Animate();
    }
    private void OnTriggerEnter(Collider other)
    {
        _rotateTween.Kill();
        Destroy(gameObject);
    }

    private void Animate()
    {
        _rotateTween = transform.DOLocalRotate(new Vector3(90, 0, 360), _animationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}
