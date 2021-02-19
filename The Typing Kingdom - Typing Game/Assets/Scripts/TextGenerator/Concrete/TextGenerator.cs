using System.Linq;

public class TextGenerator : ITextGenerator
{
	private readonly string[] words;

	public TextGenerator(string[] words)
	{
		this.words = words;
	}

	public string GenerateText()
	{
		int randomIndex = UnityEngine.Random.Range(0, words.Length - 1);
		return words[randomIndex];
	}

	public string GenerateTextWithLength(int length)
	{
		var wordsWithParticularLength = words.Where(word => word.Length == length).ToArray();
		int randomIndex = UnityEngine.Random.Range(0, wordsWithParticularLength.Length - 1);
		return wordsWithParticularLength[randomIndex];
	}
}