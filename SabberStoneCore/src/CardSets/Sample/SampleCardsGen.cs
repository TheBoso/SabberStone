using System.Collections.Generic;
using SabberStoneCore.Enums;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.src.Loader;

namespace SabberStoneCore.CardSets.Sample
{
	public static class SampleCardsGen
	{
		public static void AddAll(Dictionary<string, CardDef> cards)
		{
			cards.Add("HERO_08", new CardDef());
			cards.Add("HERO_01", new CardDef());
			cards.Add("NSH_P01", new CardDef(new Dictionary<PlayReq, int> { { PlayReq.REQ_TARGET_TO_PLAY, 0 } }, new Enchants.Power
			{
				PowerTask = new DamageTask(1, EntityType.TARGET)
			}));
			cards.Add("NSH_P02", new CardDef(new Enchants.Power
			{
				PowerTask = new ArmorTask(2)
			}));
			cards.Add("NSH_001", new CardDef());
			cards.Add("NSH_002", new CardDef());
			cards.Add("NSH_003", new CardDef(new Dictionary<PlayReq, int> { { PlayReq.REQ_TARGET_TO_PLAY, 0 } }, new Enchants.Power
			{
				PowerTask = new DamageTask(3, EntityType.TARGET)
			}));
			cards.Add("NSH_004", new CardDef(new Enchants.Power
			{
				PowerTask = new DrawTask()
			}));
		}
	}
}
