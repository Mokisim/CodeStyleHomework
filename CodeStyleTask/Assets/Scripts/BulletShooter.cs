using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootingTarget;
    [SerializeField] private float _shootingPower;
    [SerializeField] private float _shootingFrequency;

    private Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            _bullet.SetBulletDirection((_shootingTarget.position - transform.position).normalized);
            _bullet = Instantiate(_bullet, transform.position + _bullet.BulletDirection, Quaternion.identity);
            _bullet.Fly(_shootingPower);

            yield return new WaitForSeconds(_shootingFrequency);
        }
    }
}
