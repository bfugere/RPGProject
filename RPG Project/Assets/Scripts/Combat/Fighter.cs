using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        
        Transform target;
        Mover mover;
        ActionScheduler actionScheduler;
        Animator animator;

        void Start()
        {
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (target == null)
                return;
            
            if (target != null && !GetIsInRange())
                mover.MoveTo(target.position);
            else
            {
                mover.Cancel();
                AttackBehavior();
            }
        }

        void AttackBehavior()
        {
            animator.SetTrigger("isAttacking");
        }

        bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionScheduler.StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        // Animation Event
        void Hit()
        {

        }
    }
}
