﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Rognir.NPCs.Rognir;
using static Terraria.ModLoader.ModContent;


namespace Rognir.Items.Rognir
{
    class YourMom : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The underworld would like this.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Rognir.Rognir>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}
