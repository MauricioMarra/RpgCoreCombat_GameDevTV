using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private MovementController movementController;
        private Fighter fighterController;

        // Start is called before the first frame update
        void Start()
        {
            movementController = GetComponent<MovementController>();
            fighterController = GetComponent<Fighter>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveToCursor();
                Attack();
            }
        }

        private void MoveToCursor()
        {
            var lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(lastRay.origin, lastRay.direction * 100, Color.red, 5);

            RaycastHit hit;
            var hasHit = Physics.Raycast(lastRay, out hit);

            if (hasHit)
            {
                movementController.MoveTo(hit.point);
            }
        }

        private void Attack()
        {
            var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

            foreach (var hit in hits)
            {
                var target = new CombatTarget();
                if (hit.transform.TryGetComponent<CombatTarget>(out target))
                {
                    fighterController.Attack();
                }
            }
        }
    }
}
