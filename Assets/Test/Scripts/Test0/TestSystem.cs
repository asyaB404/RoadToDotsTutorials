using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct TestSystem:ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<TestData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, data) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<TestData>>())
        {
            transform.ValueRW.Position += data.ValueRO.direction * data.ValueRO.speed * SystemAPI.Time.DeltaTime;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
}

