using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "AssetsReferences", menuName = "ScriptableObjects/AssetsReferences")]
public class AssetsReferencesScritable : ScriptableObject
{
	[Header("Assets")]
	public TextAsset qwertyKeyboardJsonEn;
	public TextAsset qwertyKeyboardJsonRu;
	public TextAsset wordsArrayJsonEn;
	public TextAsset wordsArrayJsonRu;
}