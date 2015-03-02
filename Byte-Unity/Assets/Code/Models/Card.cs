using System;
using System.Collections.Generic;

[Serializable]
public class Card {
	public List<Equation> equations;

	//FIXME: I just added this to both factionSet and Card because card needs it and I don't want to re-do all the data entry.
	[NonSerialized]
	public string faction;
}