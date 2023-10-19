using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    sealed class TriggerEventSystem : IEcsRunSystem
    {
        readonly EcsWorldInject _world = default;
        readonly EcsFilterInject<Inc<TriggerEvent>> _filter = default;
        readonly EcsPoolInject<TriggerEvent> _triggerEventPool = default;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref TriggerEvent triggerEventComp = ref _triggerEventPool.Value.Get(entity);
                Debug.Log($"TriggerValue = {triggerEventComp.TriggerValue}");
                _triggerEventPool.Value.Del(entity);
            }
        }
    }
}