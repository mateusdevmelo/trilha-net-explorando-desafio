namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        // Construtor padrão
        public Reserva() { }

        // Construtor com dias reservados
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Método para cadastrar hóspedes
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suíte é maior ou igual ao número de hóspedes recebidos
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção se a capacidade for menor que o número de hóspedes
                throw new Exception("Não é possível fazer a reserva: a quantidade de hóspedes ultrapassa o limite da suíte.");
            }
        }

        // Método para cadastrar uma suíte
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Método para obter a quantidade de hóspedes
        public int ObterQuantidadeHospedes()
        {
            // Retorna o número de hóspedes cadastrados
            return Hospedes != null ? Hospedes.Count : 0;
        }

        // Método para calcular o valor da diária
        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total das diárias
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplica um desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valorTotal *= 0.90m; // Aplica um desconto de 10%
            }

            return valorTotal;
        }
    }
}