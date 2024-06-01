using UnityEngine;


namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;

        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
        }
    }
}
