using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private MonoBehaviour currentAction;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void StartAction(MonoBehaviour action)
        {
            if (currentAction != null && currentAction != action)
            {
                Debug.Log($"Canceling {currentAction}");
            }

            this.currentAction = action;
        }
    }

}
