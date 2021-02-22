public class QWERTYOptions
{
	public QWERTYHandType HandType { get; set; }
	public QWERTYSectionType SectionType { get; set; }

	public QWERTYOptions(QWERTYHandType handType = QWERTYHandType.Both,
		QWERTYSectionType sectionType = QWERTYSectionType.Up | QWERTYSectionType.Middle)
	{
		HandType = handType;
		SectionType = sectionType;
	}
}