using UnityEngine;
using System;
using System.Collections;

public interface InputProvider {
	void Stream(Action<byte> onComplete);
	void ProvideFeedback(bool won, Action onComplete);
}