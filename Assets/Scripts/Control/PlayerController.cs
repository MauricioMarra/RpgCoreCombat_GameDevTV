using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private MovementController movementController;

        // Start is called before the first frame update
        void Start()
        {
            movementController = GetComponent<MovementController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveToCursor();
            }
        }

        public void MoveToCursor()
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
    }
}
