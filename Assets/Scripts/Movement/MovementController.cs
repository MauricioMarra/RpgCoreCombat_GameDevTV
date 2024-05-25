using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour
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
            animator.SetFloat("Blend", agent.velocity.magnitude);
        }

        public void MoveTo(Vector3 position)
        {
            agent.SetDestination(position);
        }
    }
}
