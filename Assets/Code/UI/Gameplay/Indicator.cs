using UnityEngine;

namespace Code.UI.Gameplay
{
    public class Indicator : MonoBehaviour
    {
        [SerializeField] private GameObject _indicator;
        
        public void Activate()
        {
            _indicator.SetActive(true);
        }

        public void Deactivate()
        {
            _indicator.SetActive(false);
        }
    }
}
