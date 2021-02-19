using System.Collections.Generic;

public class QWERTYOptions
{
	public HandType HandType { get; set; }
	public QWERTYSectionType SectionType { get; set; }

	public QWERTYOptions(HandType handType = HandType.Both,
		QWERTYSectionType sectionType = QWERTYSectionType.Up | QWERTYSectionType.Middle)
	{
		HandType = handType;
		SectionType = sectionType;
	}
}