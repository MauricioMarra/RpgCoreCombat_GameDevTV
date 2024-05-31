using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction currentAction;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void StartAction(IAction action)
        {
            if (currentAction != null && currentAction != action)
            {
                currentAction.Cancel();
            }

            this.currentAction = action;
        }
    }

}
