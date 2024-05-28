using RPG.Core;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange;

        private Transform target;
        private MovementController movementController;
        private NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            movementController = GetComponent<MovementController>();
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.target != null && Vector3.Distance(this.target.position, this.transform.position) <= weaponRange)
                agent.isStopped = true;
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
    }
}
