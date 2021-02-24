using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public WordsController WordsController { get; set; }

	public EventsManager EventsManager { get; set; }

	public ITextGenerator TextGenerator { get; set; }

	public IWordsViewSpawner WordViewGenerator { get; set; }

	public Transform TargetTransform { get; set; }

	public float CurrentWordViewSpeed { get; set; }

	public void Initalize()
	{
		WordsController.OnTypeLetterFailed += () => EventsManager.OnTypeLetterFailed?.Invoke();
	}

	public void Spawn()
	{
		Word word = new Word(TextGenerator.GenerateText());

		WordView wordView = WordViewGenerator.GenerateWordView();
		wordView.SetText(word.GetFullWord());
		wordView.SetSpeed(CurrentWordViewSpeed);
		wordView.target = TargetTransform;

		AssignWordViewEvents(wordView, word);
		AssignWordEvents(word, wordView);

		WordsController.Add(word);
	}

	private void AssignWordViewEvents(WordView wordView, Word word)
	{
		wordView.OnCollisionWithTarget.AddListener(() => WordsController.RemoveWord(word));
		wordView.OnCollisionWithTarget.AddListener(() => EventsManager.OnTargetCollisionWithWords?.Invoke());
	}

	private void AssignWordEvents(Word word, WordView wordView)
	{
		word.OnTypeLetterUpdateGetUnwrittenPart += wordView.UpdateText;
		word.OnCompleteTypingWord += wordView.RemoveWord;

		word.OnTypeLetterSuccess += () => EventsManager.OnTypeLetterSuccess?.Invoke();
		word.OnTypeLetterFailed += () => EventsManager.OnTypeLetterFailed?.Invoke();

		word.OnWrittenWordWithoutErrors += () => EventsManager.OnWrittenWordWithoutErrors?.Invoke();
		word.OnWrittenWordWithErrors += () => EventsManager.OnWrittenWordWithErrors?.Invoke();

		// Events for VFX effects
		word.OnTypeLetterFailed += () => EventsManager.OnTypeLetterFailedReturnTransform?.Invoke(wordView.transform);
		word.OnTypeLetterSuccess += () => EventsManager.OnTypeLetterSuccessReturnTransform?.Invoke(wordView.transform);
		word.OnCompleteTypingWord += () => EventsManager.OnCompleteWordReturnTransform?.Invoke(wordView.transform);
	}
}
