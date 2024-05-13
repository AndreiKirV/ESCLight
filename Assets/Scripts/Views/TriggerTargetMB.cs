using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

public class TriggerTargetMB : MonoBehaviour
{
    public EcsWorld World; // по хорошему нужен метод
    private int _value;
    private void OnTriggerEnter(Collider other) 
    {
        ref TriggerEvent trigEv = ref World.GetPool<TriggerEvent>().Add(World.NewEntity());//добавляет в пул новую сущность
        _value = Random.Range(0,101);
        trigEv.TriggerValue = _value;
    }

    private void OnTriggerExit(Collider other) 
    {
        ref TriggerEvent trigEv = ref World.GetPool<TriggerEvent>().Add(World.NewEntity());
        trigEv.TriggerValue = - _value;
        Destroy(other.gameObject);
    }
}