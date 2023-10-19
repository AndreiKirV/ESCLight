using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

public class TriggerTargetMB : MonoBehaviour
{
    public EcsWorld World; // по хорошему нужен метод
    private void OnTriggerEnter(Collider other) 
    {
        ref TriggerEvent trigEv = ref World.GetPool<TriggerEvent>().Add(World.NewEntity());//добавляет в пул новую сущность
        trigEv.TriggerValue = Random.Range(0,101);
    }
}