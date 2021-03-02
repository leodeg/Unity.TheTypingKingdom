public interface IWordsViewSpawner
{
	WordView InstantiateWordView();
	void DeactivateWordView(); // For objects pool pattern
}
