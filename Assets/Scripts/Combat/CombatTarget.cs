using UnityEngine;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {
        void Start()
        {
        }
        void Update()
        {
        }

        public bool CanAttack()
        {
            return !GetComponent<Health>().IsDead();
        }
    }
}
