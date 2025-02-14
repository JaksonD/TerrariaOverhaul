﻿using System;
using Terraria.ModLoader;

namespace TerrariaOverhaul.Common.ModEntities.Players
{
	[Autoload(Side = ModSide.Client)]
	public sealed class PlayerEffects : ModPlayer
	{
		private int forceTrailEffectTime;

		public override void Load()
		{
			On.Terraria.Player.SetArmorEffectVisuals += (orig, player, drawPlayer) => {
				orig(player, drawPlayer);

				var modPlayer = drawPlayer.GetModPlayer<PlayerEffects>();

				if (modPlayer.forceTrailEffectTime > 0) {
					player.armorEffectDrawShadow = true;

					modPlayer.forceTrailEffectTime--;
				}
			};
		}

		public void ForceTrailEffect(int forTicks)
		{
			forceTrailEffectTime = Math.Max(forceTrailEffectTime, forTicks);
		}
	}
}
