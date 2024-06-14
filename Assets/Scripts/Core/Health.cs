using UnityEngine;


namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;

        private bool isDead = false;

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);

            if (health <= 0)
                Die();
        }

        public void Die()
        {
            isDead = true;
            animator.SetTrigger("Die");
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}
