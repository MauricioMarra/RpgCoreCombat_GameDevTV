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
            if (Attack()) return;
            if (MoveToCursor()) return;

            Debug.Log("Nothing to do.");
        }

        private bool MoveToCursor()
        {
            var lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100, Color.red, 5);

            RaycastHit hit;
            var hasHit = Physics.Raycast(lastRay, out hit);

            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    movementController.MoveTo(hit.point);
                }

                return true;
            }

            return false;
        }

        private bool Attack()
        {
            var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

            foreach (var hit in hits)
            {
                CombatTarget target;
                target = hit.transform.GetComponent<CombatTarget>();

                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    fighterController.Attack();
                }

                return true;
            }

            return false;
        }
    }
}
