public interface IWordsViewSpawner
{
	WordView GenerateWordView();
	void DeactivateWordView(); // For objects pool pattern
}
