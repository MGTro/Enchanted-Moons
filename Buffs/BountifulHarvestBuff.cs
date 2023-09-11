﻿using BlueMoon.Events;
using Terraria;
using Terraria.ModLoader;

namespace BlueMoon.Buffs
{
    public class BountifulHarvestBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bountiful Harvest");
            // Description.SetDefault("The Harvest Moon's blessing fills your pockets with riches. Enemies drop more coins for you.");
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<HarvestMoonPlayer>().bountifulHarvest = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.HasBuff(Type))
            {
                if (Main.hardMode)
                {
                    npc.value *= 2f;
                }
                else
                {
                    npc.value *= 1.5f;
                }
            }
        }
    }
}