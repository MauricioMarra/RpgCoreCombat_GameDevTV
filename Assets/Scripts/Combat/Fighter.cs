using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange;
        [SerializeField] private float weaponDamage;
        [SerializeField] private float timeBetweenAttacks;

        private float countTimeBetweenAttacks = 0f;

        private Transform target;
        private MovementController movementController;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            movementController = GetComponent<MovementController>();
            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            countTimeBetweenAttacks += Time.deltaTime;

            if (this.target != null && this.target.GetComponent<Health>().IsDead())
                this.Cancel();

            if (this.target != null && Vector3.Distance(this.target.position, this.transform.position) <= weaponRange)
            {
                movementController.Cancel();

                if (countTimeBetweenAttacks >= timeBetweenAttacks)
                {
                    animator.ResetTrigger("StopAttacking");
                    animator.SetTrigger("Attack");
                    transform.LookAt(target);
                    countTimeBetweenAttacks = 0f;
                }
            }
        }

        public void StartAttack(CombatTarget target)
        {
            GetComponent<ActionScheduler>().StartAction(this);

            Attack(target);
        }

        private void Attack(CombatTarget target)
        {

            SetTarget(target);

            movementController.MoveTo(target.transform.position);

            Debug.Log("Take that you fool!");
        }

        private void SetTarget(CombatTarget target)
        {
            this.target = target.transform;
        }

        public void Cancel()
        {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("StopAttacking");
            this.target = null;
        }

        //Animation Event
        private void Hit() 
        {
            if (target != null)
            {
                target.GetComponent<Health>().TakeDamage(weaponDamage);
            }
        }
    }
}
