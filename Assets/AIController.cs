using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5f;

        private GameObject _player;

        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            var distance = Vector3.Distance(_player.transform.position, this.gameObject.transform.position);

            if (distance < chaseDistance)
                Debug.Log($"{this.gameObject.name} is chasing.");
        }
    }
}
