using RPG.Core;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

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
        private NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            movementController = GetComponent<MovementController>();
            animator = GetComponentInChildren<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            countTimeBetweenAttacks += Time.deltaTime;

            if (this.target != null && Vector3.Distance(this.target.position, this.transform.position) <= weaponRange)
            {
                movementController.Cancel();

                if (countTimeBetweenAttacks >= timeBetweenAttacks)
                {
                    animator.SetTrigger("Attack");
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
