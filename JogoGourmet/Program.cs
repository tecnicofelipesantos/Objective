using JogoGourmet.@class;
using JogoGourmet.classes;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace JogoGourmet
{
	class Program
	{
		private const string tituloMsg = "« Jogo Gourmet »";
		private const string msgQuestionaPrato = "O prato que você pensou é ";

		private static AdivinharPratoResponse AdivinharPrato(List<Prato> lista)
		{
			bool result = false;
			int index = 0;

			foreach (var item in lista)
			{
				if (MessageBox.Show($"{msgQuestionaPrato}{ValidaTipoPrato(item)}?", tituloMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (MessageBox.Show($"{msgQuestionaPrato}{item.Nome.ToLower()}?", tituloMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						result = true;
						break;
					}
					else
						break;
				}

				index++;
			}

			return new AdivinharPratoResponse(result, index);
		}

		private static string ValidaTipoPrato(Prato prato)
		{
			return (prato.Tipo != string.Empty) ? prato.Tipo.ToLower() : prato.Nome.ToLower();
		}

		private static void AdicionarNovoPrato(ref List<Prato> pratos, int lastIndex)
		{
			string nomePrato = Interaction.InputBox("Qual prato você pensou?", "Desisto");
			string tipoPrato = Interaction.InputBox($"{nomePrato} é ___________ mas {pratos[lastIndex].Nome.ToLower()} não.", tituloMsg);

			pratos.Add(new Prato(tipoPrato, nomePrato));
		}

		private static void InicializarApp(ref List<Prato> pratos)
		{
			pratos.Add(new Prato("Massa", "Lasanha"));
			pratos.Add(new Prato(string.Empty, "Bolo de chocolate"));
		}


		static void Main(string[] args)
		{
			List<Prato> pratos = [];

			InicializarApp(ref pratos);

			do
			{
				MessageBox.Show("Pense em um prato que gosta", tituloMsg);

				var result = AdivinharPrato(pratos);

				if (result.Adivinhou)
					MessageBox.Show("Acertei de novo!", tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					AdicionarNovoPrato(ref pratos, result.LastIndex);

			} while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
		}
	}
}