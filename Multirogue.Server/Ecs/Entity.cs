using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Multirogue.Common;

namespace Multirogue.Server.Ecs
{
    public class Entity
    {
        private readonly Dictionary<ComponentType, Component> _components = new Dictionary<ComponentType, Component>();

        public Guid Id { get; set; }
        public string EntityType { get; set; }
        public ImmutableDictionary<ComponentType, Component> Components { get => _components.ToImmutableDictionary(); }

        public Entity(string entityType)
        {
            Id = Guid.NewGuid();
            EntityType = entityType;
        }

        public void AddComponent(Component component)
        {
            if(component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if(_components.ContainsKey(component.CompType))
            {
                throw new Exception("Component already exists in entity");
            }

            foreach(var requiredComponent in component.RequiredComponents)
            {
                if(!_components.ContainsKey(requiredComponent))
                {
                    throw new Exception($"Required component {requiredComponent} does not exist in entity");
                }
            }

            component.OwnerEntity = this;

            _components.Add(component.CompType, component);
        }
    }
}