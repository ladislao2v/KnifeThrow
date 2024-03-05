using System.Collections;
using Code.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Code.UI.Gameplay
{
    public class ReloadView : MonoBehaviour
    {
        [SerializeField] private Transform _reloadIndicator;
        [SerializeField] private float _angle = 0.05f;
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _rotating;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _rotating = _coroutineRunner.StartCoroutine(Rotating());
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _coroutineRunner.StopCoroutine(_rotating);
        }

        private IEnumerator Rotating()
        {
            float angle = 0;
            _reloadIndicator.transform.Rotate(Vector3.forward, angle);

            while (true)
            {
                angle += _angle;
                _reloadIndicator.transform.Rotate(Vector3.forward, -angle);
                
                yield return null;
            }
        }
    }
}