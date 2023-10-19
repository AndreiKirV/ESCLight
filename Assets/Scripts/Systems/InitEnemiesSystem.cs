using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    sealed class InitEnemiesSystem : IEcsInitSystem
    {
        readonly EcsWorldInject _world = default;
        readonly EcsPoolInject <Move> _movePool = default;
        readonly EcsPoolInject <View> _viewPool = default;
        readonly EcsPoolInject <Enemy> _enemyPool = default;

        public void Init(IEcsSystems systems)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy"); //поиск объекта на сцене
            //EcsWorld world = systems.GetWorld(); //получили ссылку на мир

            foreach (var item in gos)
            {
                int entity = _world.Value.NewEntity(); //создали новую сущность

                //ref Move moveComp = ref _world.Value.GetPool<Move>().Add(entity); //добавили сущность в пул Move (повесили компонент на ентити)
                ref Move moveComp = ref _movePool.Value.Add(entity);
                moveComp.Speed = Random.Range(1f,(float)gos.Length);

                //ref var viewComp = ref _world.Value.GetPool<View>().Add(entity);
                ref var viewComp = ref _viewPool.Value.Add(entity);
                viewComp.Transform = item.transform;//сохранили ссылку на трансформ

                //ref Enemy playerComp = ref _world.Value.GetPool<Enemy>().Add(entity);
                ref Enemy enemyComp = ref _enemyPool.Value.Add(entity);

                if(item.TryGetComponent<Rigidbody>(out Rigidbody rig))
                {
                    viewComp.Rigidbody = rig;
                }

                if(item.TryGetComponent<TriggerTargetMB>(out TriggerTargetMB triggerTargetMB))
                {
                    triggerTargetMB.World = _world.Value;
                }
            }

        }
    }
}