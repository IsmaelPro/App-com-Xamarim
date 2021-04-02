namespace App3.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado => string.Format("R$ {0}", Preco);
        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public string PrecoTotalFormatado => string.Format("Valor Total: R${0}", Preco
            + (TemFreioABS ? FREIO_ABS : 0)
            + (TemArCondicionado ? AR_CONDICIONADO : 0)
            + (TemMP3Player ? MP3_PLAYER : 0));
    }
}