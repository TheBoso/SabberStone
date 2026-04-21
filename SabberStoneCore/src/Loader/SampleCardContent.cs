using System;
using System.Collections.Generic;
using SabberStoneCore.CardSets.Sample;
using SabberStoneCore.src.Loader;

namespace SabberStoneCore.Loader
{
	public static class SampleCardContent
	{
		public static CardContentDefinition Create()
		{
			return new CardContentDefinition(
				name: "Sample",
				cardXmlResourceName: "SabberStoneCore.Resources.SampleCardDefs.xml",
				cardDefinitionRegistrars: new Action<IDictionary<string, CardDef>>[]
				{
					cards => SampleCardsGen.AddAll((Dictionary<string, CardDef>)cards)
				});
		}
	}
}
