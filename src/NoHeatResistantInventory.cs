using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;

[assembly: ModInfo("No Heat Resistant Inventory",
    Authors = new[] { "Craluminum2413" })]

namespace NoHeatResistantInventory;

public class Core : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        base.Start(api);
        api.RegisterEntityBehaviorClass("NHRI_EntityBehaviorNoHeatResistantInventory", typeof(EntityBehaviorNoHeatResistantInventory));
        api.Event.OnEntitySpawn += AddEntityBehaviors;
        api.World.Logger.Event("started 'No Heat Resistant Inventory' mod");
    }

    private void AddEntityBehaviors(Entity entity)
    {
        if (entity is EntityPlayer) entity.AddBehavior(new EntityBehaviorNoHeatResistantInventory(entity));
    }
}