using UnityEngine;

namespace Code.UI.Gameplay
{
    public class CursorView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private void Update()
        {
            _rectTransform.position = Input.mousePosition;
        }
    }
}