using System.Collections;
using UnityEngine;

namespace GMPR2512.Assignment1
{
    public class FreezeBox : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private float _freezeTime;
        [SerializeField] private float _freezeResetTime;
        private bool _canFreeze = true;
        private Vector2 _ballPreviousVelocity;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ball") && _canFreeze)
            {
                Rigidbody2D rb = collider2D.GetComponent<Rigidbody2D>();
                StartCoroutine(FreezeBall(rb));
            }
        }

        private IEnumerator FreezeBall(Rigidbody2D rb)
        {
            _canFreeze = false;
            _ballPreviousVelocity = rb.linearVelocity;
            rb.bodyType = RigidbodyType2D.Static;
            yield return new WaitForSeconds(_freezeTime);
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.linearVelocity = _ballPreviousVelocity;
            yield return new WaitForSeconds(_freezeResetTime);
            _canFreeze = true;
        }
    }
}
