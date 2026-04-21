using System;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Model;
using SabberStoneCore.src.Loader;

namespace SabberStoneCore.Loader
{
	public sealed class CardContentDefinition
	{
		public CardContentDefinition(
			string name,
			string cardXmlResourceName,
			IEnumerable<Action<IDictionary<string, CardDef>>> cardDefinitionRegistrars = null,
			Action<IDictionary<string, Card>> postLoadAction = null)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Content name is required.", nameof(name));
			if (string.IsNullOrWhiteSpace(cardXmlResourceName))
				throw new ArgumentException("Card XML resource name is required.", nameof(cardXmlResourceName));

			Name = name;
			CardXmlResourceName = cardXmlResourceName;
			CardDefinitionRegistrars = (cardDefinitionRegistrars ?? Enumerable.Empty<Action<IDictionary<string, CardDef>>>()).ToArray();
			PostLoadAction = postLoadAction;
		}

		public string Name { get; }

		public string CardXmlResourceName { get; }

		public IReadOnlyList<Action<IDictionary<string, CardDef>>> CardDefinitionRegistrars { get; }

		public Action<IDictionary<string, Card>> PostLoadAction { get; }
	}

	public static class CardContent
	{
		private static CardContentDefinition _current = HearthstoneCardContent.Create();

		public static CardContentDefinition Current => _current;

		public static void Configure(CardContentDefinition definition)
		{
			_current = definition ?? throw new ArgumentNullException(nameof(definition));
		}
	}
}
