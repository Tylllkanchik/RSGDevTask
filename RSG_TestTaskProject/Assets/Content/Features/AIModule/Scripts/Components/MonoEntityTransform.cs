using System;

namespace Content.Features.AIModule.Scripts.Components
{
    public class MonoEntityTransform : MonoComponent<EntityTransformComponent>
    {
        public override Type ComponentType => typeof(EntityTransformComponent);

        protected override EntityTransformComponent CreateNewComponent()
        {
            return new EntityTransformComponent();
        }

        protected override void DataBinded()
        {
            base.DataBinded();
            transform.position = _component.Position;
            transform.rotation = _component.Rotation;
        }

        private void Update()
        {
            if(_component != null)
            {
                _component.UpdateData(transform);
            }
        }
    }
}
