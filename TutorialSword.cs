using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace TutorialMod.Items
{
    public class TutorialSword : ModItem
    {
        bool just_applied = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Sword");
            Tooltip.SetDefault("This is a cool sword!\nTimeParadox's tutorial.");

        }

        public override void SetDefaults()
        {
            //Stats
            Item.damage = 500;
            Item.DamageType = DamageClass.Melee;
            Item.width = 128;
            Item.height = 128;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 1000;
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 50;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TutorialMaterial>(), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            player.AddBuff(BuffID.Wrath, 300);
            player.AddBuff(BuffID.Rage, 300);
            player.AddBuff(BuffID.Inferno, 300);
            player.Heal((player.statLife/4) * -1);
            Item.damage = Item.damage * 10;
            just_applied = true;
            return true;
        }

        public override void UseAnimation(Player player)
        {
            if (just_applied)
            {
                just_applied = false;
            }

            else
            {
                Item.damage = 500;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, damage);
        }
    }
}
