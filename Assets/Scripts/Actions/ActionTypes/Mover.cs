using UnityEngine;
using UnityEngine.AI;

namespace EssentialAssets.Actions
{
    public class Mover: MonoBehaviour, IAction
    {
        [Header("Specification")]
        [SerializeField] private float goalTolerance = 0.5f;
        
        private NavMeshAgent _agent;
        private ActionManager _actionManager;
        private Animator _animator;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _actionManager = GetComponent<ActionManager>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateMoveAnimation();
        }

        public void StartMoveAction(Vector3 goal)
        {
            _actionManager.StartAction(this);
            MoveTo(goal);
        }

        public void MoveTo(Vector3 goal)
        {
            _agent.SetDestination(goal);
            _agent.isStopped = false;
        }

        public bool ReachedGoal(Vector3 goal)
        {
            return Vector3.Distance(transform.position, goal) < goalTolerance;
        }

        public void SetMovementSpeed(float newSpeed)
        {
            _agent.speed = newSpeed;
        }
        
        private void UpdateMoveAnimation()
        {
            var localVelocity = transform.InverseTransformDirection(_agent.velocity);
            var speed = localVelocity.z;
            _animator.SetFloat("forwardSpeed", speed);
        }

        public void CancelAction()
        {
            _agent.isStopped = true;
        }
    }
}