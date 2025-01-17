using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MonoBarkTest : MonoBehaviour
{
    public float speed = 1;
    public float3 direction = float3.zero;
}

class MonoBarkTestAuthoring : Baker<MonoBarkTest>
{
    public override void Bake(MonoBarkTest authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new TestData
        {
            speed = authoring.speed,
            direction = authoring.direction,
        });
    }
}