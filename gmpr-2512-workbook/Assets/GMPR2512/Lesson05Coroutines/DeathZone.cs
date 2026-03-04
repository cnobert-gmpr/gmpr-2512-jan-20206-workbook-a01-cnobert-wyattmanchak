using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ball"))
            {
                GameObject ball = collider2D.gameObject;
                StartCoroutine(RespawnBall(ball));
            }
        }

        private IEnumerator RespawnBall(GameObject ball)
        {
            yield return new WaitForSeconds(2); 
            ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            ball.transform.position = _spawnPoint.position;
        }
    } 
}
