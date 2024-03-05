using Code.Services.ShootService;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Code.UI.Gameplay
{
    public class BackgroundView : MonoBehaviour, IPointerClickHandler
    {
        private IShootService _shootService;

        [Inject]
        private void Construct(IShootService shootService)
        {
            _shootService = shootService;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _shootService.Shoot();
        }
    }
}
