using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class DropTarget : MonoBehaviour
    {
        [SerializeField] private Color _hitColour = Color.darkTurquoise;
        [SerializeField] private float _hideDelay = 0.1f, _resetDelay = 2f;

        private bool _isDown = false;
        private SpriteRenderer _renderer;
        private Color _originalColour;

        void Awake()
        {
            _renderer = this.gameObject.GetComponent<SpriteRenderer>();
            _originalColour = _renderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && !_isDown)
            {
                _isDown = true;
                _renderer.color = _hitColour;
                Invoke(nameof(HideTarget), _hideDelay);
            }
        }

        void HideTarget()
        {
            gameObject.SetActive(false);
            Invoke(nameof(ResetTarget), _resetDelay);
        }
        void ResetTarget()
        {
            _renderer.color = _originalColour;
            gameObject.SetActive(true);
            _isDown = false;
        }
    }
}
