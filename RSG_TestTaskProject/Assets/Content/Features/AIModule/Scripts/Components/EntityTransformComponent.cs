using System;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Components
{
    public class EntityTransformComponent : IComponent
    {
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public EntityTransformComponent()
        {
            Position = Vector3.zero;
            Rotation = Quaternion.identity;
        }

        public EntityTransformComponent(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void UpdateData(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }
    }
}
