using UnityEngine;

public class FollowingPoints : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] points;
    private int _currentPoint;
    public float _speed;

    private void Awake()
    {
        points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            points[i] = _path.GetChild(i);
        }
    }
    
    private void Update()
    {
        Transform target = points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        _currentPoint++;

        if (_currentPoint == points.Length)
        {
            _currentPoint = 0;
        }

        Vector3 currentPointVector = points[_currentPoint].position;
        transform.forward = currentPointVector - transform.position;
    }
}
