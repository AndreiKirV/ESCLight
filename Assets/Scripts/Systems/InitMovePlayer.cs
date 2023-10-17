using Leopotam.EcsLite;
using UnityEngine;

namespace Client 
{
    sealed class InitMovePlayer : IEcsInitSystem 
    {
         public void Init (IEcsSystems systems) 
        {
            GameObject go = GameObject.Find("Player"); //поиск объекта на сцене
            EcsWorld world = systems.GetWorld(); //получили ссылку на мир
            int entity = world.NewEntity(); //создали новую сущность

            ref Move moveComp = ref world.GetPool<Move>().Add(entity); //добавили сущность в пул Move (повесили компонент на ентити)
            moveComp.Speed = 5;

            ref var viewComp = ref world.GetPool<View>().Add(entity);
            viewComp.Transform = go.transform;//сохранили ссылку на трансформ
        }
    }
}