using Microsoft.Xna.Framework;
using System.Diagnostics;
using TutorialMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Intrinsics.X86;

namespace TutorialMod.Enemies
{
    public class HallowedSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Slimme");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 64;
            NPC.damage = 100;
            NPC.defense = 50;
            NPC.lifeMax = 5000;
            NPC.value = 200f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AnimationType = NPCID.GreenSlime;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }

            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, damage * 3);
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.HallowedBar, Main.rand.Next(3, 5));
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<TutorialMaterial>(), Main.rand.Next(3, 4));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0.5f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.AddBuff(BuffID.Shine, 9999999);
        }
    }
}