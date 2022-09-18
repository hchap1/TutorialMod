using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace TutorialMod.Items
{
    public class TutorialMaterial : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Material");
            Tooltip.SetDefault("Used to craft Tutorial Sword\nThis is a new line");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.buyPrice(gold: 1);
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
