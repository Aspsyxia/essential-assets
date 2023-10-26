using System;
using UnityEngine;
using UnityEngine.AI;

namespace EssentialAssets.Ai
{
    public class Mover: MonoBehaviour, IAction
    {
        [Header("Specification")]
        [SerializeField] private float goalTolerance = 0.5f;
        
        private NavMeshAgent _agent;
        private ActionManager _actionManager;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _actionManager = GetComponent<ActionManager>();
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
            var velocity = GetComponent<NavMeshAgent>().velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        public void CancelAction()
        {
            _agent.isStopped = true;
        }
    }
}