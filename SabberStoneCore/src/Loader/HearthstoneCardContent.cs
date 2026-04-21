using System;
using System.Collections.Generic;
using SabberStoneCore.CardSets;
using SabberStoneCore.CardSets.Adventure;
using SabberStoneCore.CardSets.Standard;
using SabberStoneCore.Model;
using SabberStoneCore.src.Loader;

namespace SabberStoneCore.Loader
{
	public static class HearthstoneCardContent
	{
		public static CardContentDefinition Create()
		{
			return new CardContentDefinition(
				name: "Hearthstone",
				cardXmlResourceName: "SabberStoneCore.Resources.CardDefs.xml",
				cardDefinitionRegistrars: new Action<IDictionary<string, CardDef>>[]
				{
					cards => CoreCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => Expert1CardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => NaxxCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => GvgCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => BrmCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => TgtCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => LoeCardsGen.AddAll((Dictionary<string, CardDef>)cards),
					cards => BrmCardsGenAdv.AddAll((Dictionary<string, CardDef>)cards),
					cards => NaxxCardsGenAdv.AddAll((Dictionary<string, CardDef>)cards),
					cards => LoeCardsGenAdv.AddAll((Dictionary<string, CardDef>)cards)
				},
				postLoadAction: cards =>
				{
					// Temporary fix for Lotus Assassin.
					cards["CFM_634"].Stealth = true;
					cards["CFM_634"].Tags[Enums.GameTag.STEALTH] = 1;

					// Filtered out cards for cosmetic purposes.
					cards.Remove("HERO_01c");
				});
		}
	}
}
