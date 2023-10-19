using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client 
{
    sealed class InitMovePlayer : IEcsInitSystem 
    {
        readonly EcsWorldInject _world = default;
        readonly EcsPoolInject<Move> _movePool = default;
        readonly EcsPoolInject<View> _viewPool = default;
        readonly EcsPoolInject<Player> _playerPool = default;
         public void Init (IEcsSystems systems) 
        {
            GameObject go = GameObject.FindWithTag("Player"); //поиск объекта на сцене
            //EcsWorld world = systems.GetWorld(); //получили ссылку на мир
            int entity = _world.Value.NewEntity(); //создали новую сущность

            //ref Move moveComp = ref _world.Value.GetPool<Move>().Add(entity); //тоже, что ниже, но не по библиотеке Leopotam.EcsLite.Di
            ref Move moveComp = ref _movePool.Value.Add(entity); //добавили сущность в пул Move (повесили компонент на ентити)
            moveComp.Speed = 5;

            ref View viewComp = ref _viewPool.Value.Add(entity);
            viewComp.Transform = go.transform;//сохранили ссылку на трансформ

            ref Player playerComp = ref _playerPool.Value.Add(entity);
        }
    }
}