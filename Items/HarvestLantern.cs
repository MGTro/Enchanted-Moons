﻿using BlueMoon.Events;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BlueMoon.Items
{
    public class HarvestLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Harvest Lantern");
            // Tooltip.SetDefault("Summons a festive Harvest Moon at night");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 50);
            Item.maxStack = 20;

            Item.width = 20;
            Item.height = 20;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;

            Item.consumable = true;
            Item.noMelee = true;

            Item.UseSound = SoundID.Item44;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.Topaz, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && !BlueMoonEvent.blueMoon && !CherryMoonEvent.cherryMoon && !HarvestMoonEvent.harvestMoon && !Main.pumpkinMoon && !Main.snowMoon;
        }

        public override bool? UseItem(Player player)
        {
            HarvestMoonEvent.StartHarvestMoon();
            return true;
        }
    }
}