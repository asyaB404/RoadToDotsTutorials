using Unity.Burst;
using Unity.Entities;

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
        foreach (var (data, entity) in SystemAPI.Query<RefRW<TestData>>().WithEntityAccess())
        {
            data.ValueRW.position += data.ValueRO.direction * data.ValueRO.speed * SystemAPI.Time.DeltaTime;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
}

