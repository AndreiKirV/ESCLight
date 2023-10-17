using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class RunMovePlayer : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<Move>().End();
            EcsPool<Move> movePool = world.GetPool<Move>();
            EcsPool<View> viewePool = world.GetPool<View>();

            foreach (var entity in filter)
            {
                ref Move moveComp = ref movePool.Get(entity);
                ref View viewComp = ref viewePool.Get(entity);

                viewComp.Transform.position += Vector3.forward * moveComp.Speed * Time.deltaTime;
            }
        }
    }
}