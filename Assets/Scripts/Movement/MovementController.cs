using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour, IAction
    {
        private NavMeshAgent agent;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            var velocity = agent.velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            animator.SetFloat("Blend", speed);

            //animator.SetFloat("Blend", agent.velocity.magnitude);
        }

        public void StartMove(Vector3 position)
        {
            GetComponent<ActionScheduler>().StartAction(this);

            MoveTo(position);
        }

        public void MoveTo(Vector3 position)
        {
            agent.SetDestination(position);
            agent.isStopped = false;
        }

        public void Cancel()
        {
            agent.isStopped = true;
        }
    }
}
