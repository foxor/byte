using UnityEngine;
using System;
using System.Collections;

public interface InputProvider {
	void Stream(Action<int> onComplete);
	void Play(Action<int> onComplete);
	void ProvideFeedback(bool won, Action onComplete);
}