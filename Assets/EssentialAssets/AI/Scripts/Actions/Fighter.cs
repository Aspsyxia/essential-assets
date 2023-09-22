using UnityEngine;
using Core;

namespace Ai
{
    public class Fighter: MonoBehaviour, IAction
    {
        [SerializeField] private float range = 3f;
        [SerializeField] private float attackCooldown = 0.5f;
        
        private Health _target;
        private Mover _mover;
        private float _timeSinceLastAttack = Mathf.Infinity;

        private void Start()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (!CanAttack(_target)) return;
            _timeSinceLastAttack += Time.deltaTime;
            
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
            transform.LookAt(_target.transform.position);
            if (_timeSinceLastAttack > attackCooldown)
            {
                GetComponent<Animator>().SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
        }

        public bool CanAttack(Health target)
        {
            return target != null && !target.IsDead;
        }

        private bool InRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) <= range;
        }
        
        private void StopAttackAnimation()
        {
            GetComponent<Animator>().ResetTrigger("cancelAttack");
            GetComponent<Animator>().SetTrigger("cancelAttack");
        }

        public void Hit()
        {
            if (_target == null) return;
            _target.TakeDamage(1); 
        }

        public void CancelAction()
        {
            StopAttackAnimation();
            _target = null;
        }
    }
}