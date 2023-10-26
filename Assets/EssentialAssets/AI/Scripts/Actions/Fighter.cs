using UnityEngine;
using EssentialAssets.Core;

namespace EssentialAssets.Ai
{
    public class Fighter: MonoBehaviour, IAction
    {
        [SerializeField] private float range = 3f;
        [SerializeField] private float attackCooldown = 0.5f;
        
        private Health _target;
        private Mover _mover;
        private Animator _animator;
        private float _timeSinceLastAttack = Mathf.Infinity;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!CanAttack(_target)) return;
            _timeSinceLastAttack += Time.deltaTime;
            FaceTarget();
            if (!InRange())
            {
                _mover.MoveTo(_target.transform.position);
            }
            else
            {
                Attack();
            }
        }
        
        public void SetAttackTarget(CombatTarget combatTarget)
        {
            GetComponent<ActionManager>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();
        }

        private void Attack()
        {
            if (_timeSinceLastAttack > attackCooldown)
            {
                _animator.SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
        }
        
        private void FaceTarget()
        {
            var targetPosition = new Vector3( _target.transform.position.x, 
                transform.position.y, 
                _target.transform.position.z ) ;
            transform.LookAt( targetPosition ) ;
        }

        private bool CanAttack(Health target)
        {
            return target != null && !target.IsDead;
        }

        private bool InRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) <= range;
        }
        
        public void Hit()
        {
            if (_target == null) return;
            if (InRange())
            {
                print("Taking damage");
                _target.TakeDamage(1);
            }
        }

        public void CancelAction()
        {
            StopAttackAnimation();
            _target = null;
        }
        
        private void StopAttackAnimation()
        {
            _animator.ResetTrigger("cancelAttack");
            _animator.SetTrigger("cancelAttack");
        }
    }
}