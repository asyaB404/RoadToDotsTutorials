// using Unity.Entities.Entity;

using Unity.Entities;
using Unity.Mathematics;

public struct TestData : IComponentData
{
    public float speed;
    public float3 direction;
    public float3 position;
}