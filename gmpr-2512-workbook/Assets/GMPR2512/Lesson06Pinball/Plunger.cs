using System;
using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class Plunger : MonoBehaviour
    {
        [SerializeField] private Transform _lowestPoint, _stopPoint;
        [SerializeField] private float _velocity = -2, _force = 40;
        private Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            bool spacePressed = Input.GetKey(KeyCode.Space);
            bool spaceReleased = Input.GetKeyUp(KeyCode.Space);

            if (spacePressed && transform.position.y >= _lowestPoint.position.y)
            {
                MoveDown();
            }
            else if (spaceReleased)
            {
                ReleasePlunger();
            }
        }

        private void MoveDown()
        {
            float moveAmount = _velocity * Time.deltaTime;
            transform.Translate(0, moveAmount, 0, Space.Self);
        }

        private void ReleasePlunger()
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            float distance = _stopPoint.position.y - transform.position.y;
            Vector2 impulse = new Vector2(0, _force * distance);
            _rb.AddForce(impulse, ForceMode2D.Impulse);
        }
    }
}
