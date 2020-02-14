﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Rognir.Items
{
    class RognirsAnchor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a test");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.pick = 100;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 6000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].friendly)
                {
                    float distance = (Main.npc[i].Center - player.Center).Length();
                    if (distance < 420f)
                    {
                        Main.npc[i].AddBuff(BuffType<Buffs.Anchored>(), 180);
                    }
                }
            }

            if (Main.rand.NextFloat() < 0.85f)
            {
                float xOffset = Main.rand.Next(-420, 420);
                float yOffset = Main.rand.Next(-420, 420);

                Vector2 position = new Vector2(player.Center.X + xOffset, player.Center.Y + yOffset);
                float distance = (player.Center - position).Length();
                if (distance <= 420)
                {
                    Dust.NewDust(position, 200, 200, DustID.Vortex);
                }
            }
            return true;
        }

    }
}
