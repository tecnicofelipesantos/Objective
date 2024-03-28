namespace JogoGourmet.classes
{
	public class AdivinharPratoResponse
	{
		public bool Adivinhou { get; set; }
		public int LastIndex { get; set; }

		
		public AdivinharPratoResponse(bool adivinhou, int lastIndex)
		{
			Adivinhou = adivinhou;
			LastIndex = lastIndex;
		}
	}
}
