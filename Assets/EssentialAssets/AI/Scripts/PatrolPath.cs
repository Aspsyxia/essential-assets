using UnityEngine;

namespace Ai
{
    public class PatrolPath: MonoBehaviour
    {
        [SerializeField] private float waypointSize = 0.5f;
        
        public GameObject[] waypoints;

        private int _currentWaypoint;
        private int _pathLenght;

        private void Start()
        {
            _pathLenght = waypoints.Length;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            if (_pathLenght == 0) return;
            for (var i = 0; i < _pathLenght; i++)
            {
                Gizmos.DrawSphere(waypoints[i].transform.position, waypointSize);
                if (i != _pathLenght - 1)
                    Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }
        }

        public Vector3 GetNextWaypoint()
        {
            return waypoints[_currentWaypoint].transform.position;
        }

        public void SwitchWaypoints()
        {
            if (_currentWaypoint + 1 == _pathLenght) _currentWaypoint = 0;
            else _currentWaypoint++;
        }
    }
}