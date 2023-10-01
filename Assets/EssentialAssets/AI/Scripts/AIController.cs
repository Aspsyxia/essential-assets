using UnityEngine;
using Core;

namespace Ai
{
    public class AIController : MonoBehaviour
    {
        [Header("Specification")] 
        [SerializeField] private bool playerIsTarget = true;
        
        [Header("Patrol path")] 
        [SerializeField] private PatrolPath path;

        [Header("Ranges")] 
        [SerializeField] private float detectionRange;

        [Header("Time intervals")] 
        [SerializeField] private float suspicionInterval;
        [SerializeField] private float patrollingInterval;
        
        [Header("States speed")]
        [SerializeField] private float patrollingSpeed = 2f;
        [SerializeField] private float chaseSpeed = 3.5f;
        
        private CombatTarget _target;
        private Vector3 _nextWaypoint;
        
        private Fighter _attack;
        private Mover _mover;
        private ActionManager _manager;
        
        private float _timeSinceLastChase;
        private float _timeSinceLastMovement;
        
        private void Start()
        {
            _attack = GetComponent<Fighter>();
            _mover = GetComponent<Mover>();
            _manager = GetComponent<ActionManager>();
            
            if (playerIsTarget) _target = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatTarget>();
            if (path != null) _nextWaypoint = path.GetNextWaypoint();
            
            _mover.SetMovementSpeed(patrollingSpeed);
            _timeSinceLastChase = suspicionInterval;
            _timeSinceLastMovement = patrollingInterval;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }

        private void Update()
        {
            if (GetComponent<Health>().IsDead)
            {
                _manager.StopCurrentAction();
                return;
            }
            if (TargetInRange(_target.gameObject))
            {
                AttackBehaviour();
            }
            else if (_timeSinceLastChase < suspicionInterval)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrollingBehaviour();
            }
            TimeIntervalsIncrease();
        }

        private void AttackBehaviour()
        {
            _timeSinceLastChase = 0f;
            _attack.SetAttackTarget(_target);
            _mover.SetMovementSpeed(chaseSpeed);
            _mover.MoveTo(_target.transform.position);
        }

        private void SuspicionBehaviour()
        {
            _manager.StopCurrentAction();
        }

        private void PatrollingBehaviour()
        {
            _mover.SetMovementSpeed(patrollingSpeed);

            if (path == null) return;
            if (_mover.ReachedGoal(_nextWaypoint))
            {
                _timeSinceLastMovement = 0f;
                path.SwitchWaypoints();
            }

            _nextWaypoint = path.GetNextWaypoint();
                
            if (_timeSinceLastMovement >= patrollingInterval)
            {
                _mover.StartMoveAction(_nextWaypoint);
            }
        }

        private bool TargetInRange(GameObject target)
        {
            return !target.GetComponent<Health>().IsDead && Vector3.Distance(transform.position, target.transform.position) < detectionRange;
        }

        private void TimeIntervalsIncrease()
        {
            _timeSinceLastChase += Time.deltaTime;
            _timeSinceLastMovement += Time.deltaTime;
        }
    }
}