using System.Collections;
using UnityEngine;

namespace GMPR2512.Assignment1
{
    public class Portal : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private float _portalInnactiveTime;
        public bool _canTeleport = true;

        [Header("Refrences")]
        [SerializeField] private GameObject _siblingPortal;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ball") && _canTeleport)
            {
                StartCoroutine(ExitPortal());
                Rigidbody2D rb = collider2D.GetComponent<Rigidbody2D>();
                rb.linearVelocity = _siblingPortal.transform.rotation * rb.linearVelocity;
                collider2D.transform.position = _siblingPortal.transform.position;
            }
        }

        private IEnumerator ExitPortal()
        {
            Portal _siblingPortalScript = _siblingPortal.GetComponent<Portal>();
            _siblingPortalScript._canTeleport = false;
            yield return new WaitForSeconds(_portalInnactiveTime);
            _siblingPortalScript._canTeleport = true;
        }
    }
}
