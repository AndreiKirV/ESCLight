using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    sealed class RunMovePlayer : IEcsRunSystem
    {
        readonly EcsWorldInject _world = default;
        readonly EcsFilterInject<Inc<Move, Enemy>, Exc<Player>> _filter = default;//инжект происходит в стартапе перед инитом
        readonly EcsPoolInject<Move> _movePool = default;
        readonly EcsPoolInject<View> _viewePool = default;
        public void Run(IEcsSystems systems)
        {
            //EcsWorld world = systems.GetWorld();//берем мир
            //EcsFilter filter = world.Filter<Move>().Inc<Enemy>().Inc<View>().Exc<Player>().End();//фильтр отбирает все сущности на которых есть компонент Move (в данном случае и включает компонент Enemy и исключает компонент Player)
            //EcsPool<Move> movePool = _world.GetPool<Move>();
            //EcsPool<View> viewePool = _world.GetPool<View>();

            foreach (var entity in _filter.Value)
            {
                ref Move moveComp = ref _movePool.Value.Get(entity);
                ref View viewComp = ref _viewePool.Value.Get(entity);
                
                if(viewComp.Rigidbody == null)
                viewComp.Transform.position += Vector3.forward * moveComp.Speed * Time.deltaTime;
                else
                viewComp.Rigidbody.MovePosition(viewComp.Transform.position += Vector3.forward * moveComp.Speed * Time.deltaTime);
            }
        }
    }
}