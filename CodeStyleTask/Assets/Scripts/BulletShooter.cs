using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootingTarget;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _number;
    [SerializeField] private float _shootingFrequency;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 bulletDirection = (_shootingTarget.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position + bulletDirection, Quaternion.identity);

            newBullet.transform.up = bulletDirection;
            newBullet.GetComponent<Rigidbody>().velocity = bulletDirection * _number;

            yield return new WaitForSeconds(_shootingFrequency);
        }
    }
}
