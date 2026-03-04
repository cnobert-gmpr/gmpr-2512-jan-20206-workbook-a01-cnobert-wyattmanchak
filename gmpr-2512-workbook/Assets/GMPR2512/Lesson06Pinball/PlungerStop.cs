using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class PlungerStop : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.name == "Plunger")
            {
                collider.attachedRigidbody.linearVelocity = Vector2.zero;
                collider.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}
