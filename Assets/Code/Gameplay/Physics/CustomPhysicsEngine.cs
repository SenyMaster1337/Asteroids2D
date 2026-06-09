using UnityEngine;

namespace Code.Gameplay.Physics
{
    public static class CustomPhysicsEngine
    {
        public static Vector2 AddForce(Vector2 velocity, Vector2 force, float mass, float deltaTime,
            float maxSpeed = float.MaxValue)
        {
            velocity += force / mass * deltaTime;
            return Vector2.ClampMagnitude(velocity, maxSpeed);
        }

        public static Vector3 MovePosition(Vector3 position, Vector2 velocity, float deltaTime)
        {
            return position + (Vector3)velocity * deltaTime;
        }

        public static Quaternion MoveRotation(Quaternion rotation, float angularVelocity, float deltaTime)
        {
            return rotation * Quaternion.Euler(0f, 0f, angularVelocity * deltaTime);
        }
    }
}