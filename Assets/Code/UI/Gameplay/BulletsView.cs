using System;
using UnityEngine;

namespace Code.UI.Gameplay
{
    public class BulletsView : MonoBehaviour
    {
        [SerializeField] private Indicator[] _indicators;

        private int _activeCount;

        private void Start()
        {
            _activeCount = _indicators.Length;
        }

        public void Reset()
        {
            _activeCount = _indicators.Length;
            
            foreach (var indicator in _indicators)
                indicator.Activate();
        }

        public void OnShot()
        {
            if(_activeCount < 0)
                return;

            --_activeCount;
            _indicators[_activeCount].Deactivate();
        }
    }
}
