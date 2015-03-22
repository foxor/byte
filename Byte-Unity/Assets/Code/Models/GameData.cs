using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameData {
	public byte[] players;
	public List<Card> buffer;
	public Stack<Card>[] stacks;
	public EvaluationContext context;

	public GameData(CardSet[] sets, int playerCount) {
		players = new byte[playerCount];

		buffer = new List<Card>();

		stacks = new Stack<Card>[9];
		for (int i = 0; i < 9; i++) {
			stacks[i] = new Stack<Card>();
		}

		IEnumerable<Card> shuffledCards = sets.SelectMany<CardSet, Card>(FlattenCardSet).OrderBy(x => Random.Range(0f, 1f));

		int nextDrawOrder = 0;
		Dictionary<string, int> drawnOrder = new Dictionary<string, int>();

		foreach (Card c in shuffledCards) {
			if (!drawnOrder.ContainsKey(c.faction)) {
				drawnOrder[c.faction] = nextDrawOrder++;
			}
			stacks[drawnOrder[c.faction]].Push(c);
		}

		while (ShouldStream()) {
			BufferCard();
		}

		context = new EvaluationContext (this);
	}

	protected IEnumerable<Card> FlattenCardSet(CardSet cs) {
		foreach (FactionSet fs in cs.factionSets) {
			foreach (Card c in fs.cards) {
				c.faction = fs.name;
				yield return c;
			}
		}
	}

	public void BufferCard() {
		int bits = RollBits.Roll();
		Card c = stacks[bits].Pop();
		buffer.Add(c);
	}

	public bool ShouldStream() {
		return stacks.All(x => x.Count > 0) && buffer.Count < 9;
	}

	public bool ShouldChoose() {
		return buffer.Count > 0;
	}

	public void PickCard(byte cardIndex, int forPlayerId) {
		Card chosen = buffer[cardIndex];
		buffer.Remove(chosen);
		players[forPlayerId] = (byte)(players[forPlayerId] - cardIndex);

		foreach (Equation e in chosen.equations) {
			e.Execute(context);
		}
	}
}