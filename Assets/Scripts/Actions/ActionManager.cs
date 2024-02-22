using UnityEngine;

namespace EssentialAssets.Actions
{
    public class ActionManager: MonoBehaviour
    {
        private IAction _currentAction;
        
        public void StartAction(IAction action)
        {
            if (_currentAction == action) return;
            if (_currentAction != null)
            {
                print("Cancelling " + _currentAction);
                _currentAction.CancelAction();
            }
            _currentAction = action;
        }

        public void StopCurrentAction()
        {
            _currentAction?.CancelAction();
        }
    }
}