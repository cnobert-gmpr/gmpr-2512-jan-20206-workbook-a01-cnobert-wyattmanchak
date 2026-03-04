using UnityEngine;

namespace GMPR.Lesson04Scripting01
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private int _year;
        private float _seconds = 0;
        private int _deathCount = 0;

        void Awake()
        {
            Debug.Log($"I am awake, the year is {_year}");
            _year += 1026;
        }

        void Start()
        {
            Debug.Log($"I'm in the start method now, and the year is {_year}");
        }

        void Update()
        {
            _seconds += Time.deltaTime;
            // Debug.Log($"This scene has been running for {_seconds} seconds.");
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            _deathCount++;
            // Debug.Log($"This bumped into me {collider.gameObject.name}");
            Debug.Log($"Death zone has deathed this many: {_deathCount}");
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.gravityScale = 0;
            }

            // Destroy(collider.gameObject);
        }
    }
}
