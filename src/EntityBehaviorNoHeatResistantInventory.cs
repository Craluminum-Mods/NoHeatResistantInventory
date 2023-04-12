using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;

namespace NoHeatResistantInventory;

public class EntityBehaviorNoHeatResistantInventory : EntityBehavior
{
    public EntityBehaviorNoHeatResistantInventory(Entity entity) : base(entity) { }

    public override void OnGameTick(float deltaTime)
    {
        base.OnGameTick(deltaTime);
        (entity as EntityPlayer)?.WalkInventory(CheckSlot);
    }

    private bool CheckSlot(ItemSlot slot)
    {
        var player = (entity as EntityPlayer)?.Player;
        if (player == null) return true;

        if (!IsPlayerInventory(slot)) return true;

        var currentGameMode = player.WorldData.CurrentGameMode;
        if (currentGameMode != EnumGameMode.Creative && currentGameMode != EnumGameMode.Spectator)
        {
            slot?.Inventory?.DropSlotIfHot(slot, player);
        }
        return true;
    }

    private static bool IsPlayerInventory(ItemSlot slot)
    {
        return slot.Inventory.ClassName is GlobalConstants.hotBarInvClassName or GlobalConstants.backpackInvClassName;
    }

    public override string PropertyName() => "noheatresistantinventory";
}