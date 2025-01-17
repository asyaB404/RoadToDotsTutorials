using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct TestSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<TestData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, data) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<TestData>>())
        {
            transform.ValueRW.Position +=
                math.normalize(data.ValueRO.direction) * data.ValueRO.speed * SystemAPI.Time.DeltaTime;
        }
        // Entities.ForEach((ref LocalTransform transform, in TestData data) =>
        // {
        //     transform.Position +=
        //         math.normalize(data.direction) * data.speed * SystemAPI.Time.DeltaTime;
        // }).ScheduleParallel();  已过时
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
}