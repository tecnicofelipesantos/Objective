namespace JogoGourmet.@class
{
    public class Prato
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }


        public Prato(string tipo, string nome)
        {
            Tipo = tipo;
            Nome = nome;
        }
    }
}
