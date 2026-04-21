# Non-Hearthstone Content Direction

The engine is still Hearthstone-shaped internally, but the startup path no longer has to hardcode Hearthstone content.

## What changed

- `SabberStoneCore.Loader.CardContent` now controls which content pack is loaded at startup.
- `SabberStoneCore.Loader.HearthstoneCardContent` is the default preset and acts as the current example implementation.
- `CardLoader` now loads whichever embedded XML resource the selected content pack points to.
- Card behavior registration is now supplied by content registrars instead of being hardwired inside the engine loader.

## What this means for new games

A new game can now be introduced as its own content pack:

1. Provide an embedded XML file with card metadata.
2. Register any code-driven behaviors for cards that are not simple vanilla bodies.
3. Call `CardContent.Configure(...)` before anything touches `SabberStoneCore.Model.Cards`.

## Current card model

Right now cards are still a two-part system:

- XML provides stats, tags, requirements, names, and IDs.
- C# registrars provide triggered effects, battlecries, deathrattles, auras, and custom logic.

That means the current answer to "how do we add new cards?" is:

- simple cards: XML only
- complex cards: XML plus C# behavior registration

## Minimal example

```csharp
CardContent.Configure(new CardContentDefinition(
	"MyGame",
	"MyGameNamespace.Resources.CardDefs.xml",
	new Action<IDictionary<string, CardDef>>[]
	{
		MyGameCoreCards.AddAll
	}));
```

There is also a tiny built-in sample content pack now:

```csharp
CardContent.Configure(SampleCardContent.Create());
```

It contains:

- 2 heroes
- 2 hero powers
- 2 vanilla minions
- 1 targeted spell implemented in C#
- 1 draw minion implemented in C#

## Good next steps

- Move Hearthstone-only helpers from `SabberStoneCore.Model.Cards` into the Hearthstone preset.
- Add a tiny sample custom content pack with 2 heroes, 2 hero powers, and a few vanilla cards.
- Decide whether future custom cards should stay `XML + C#` or move toward `JSON/YAML + scriptable effects`.
