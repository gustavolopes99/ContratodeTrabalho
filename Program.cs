using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Vault;

namespace ContratoDeTrabalho
{
    class Program
    {
        static void Main()
        {
            ViaCEP viaCEP = new ViaCEP();
            var contrato = new
            {
                Empresa = new
                {
                    RazaoSocial = "Alura Serviços Hidraulicos Ltda.",
                    CNPJ = new CNPJFormatter().Format("05677629000780"),
                    Endereco = viaCEP.GetEndereco("85812020"),
                    Numero = "123",
                },
                Funcionario = new
                {
                    Nome = "Mario Mario",
                    Nacionalidade = "Brasileiro",
                    EstadoCivil = "Solteiro",
                    RG = "123456789-00",
                    CPF = new CPFFormatter().Format("72846350027"),
                    Endereco = viaCEP.GetEndereco("85817841"),
                    NumeroResidencia = "434"
                },
                Inicio = new DateTime(2018, 1, 1).ToString("d"),
                Cargo = "Encanador",
                Salario = new Money(3108.45)
            };

            string documento = $@"                            CONTRATO INDIVIDUAL DE TRABALHO TEMPORÁRIO

EMPREGADOR: {contrato.Empresa.RazaoSocial}, com sede à {contrato.Empresa.Endereco.Logradouro}, {contrato.Empresa.Numero}, {contrato.Empresa.Endereco.Bairro}, {contrato.Empresa.Endereco.CEP}, {contrato.Empresa.Endereco.Localidade}, {contrato.Empresa.Endereco.UF}, inscrita no CNPJ sob nº {contrato.Empresa.CNPJ};

EMPREGADO: {contrato.Funcionario.Nome}, {contrato.Funcionario.Nacionalidade}, {contrato.Funcionario.EstadoCivil}, portador da cédula de identidade R.G.nº {contrato.Funcionario.RG} e CPF/ MF nº {contrato.Funcionario.CPF}, residente e domiciliado na {contrato.Funcionario.Endereco.Logradouro}, {contrato.Funcionario.NumeroResidencia}, {contrato.Funcionario.Endereco.Bairro}, {contrato.Funcionario.Endereco.CEP}, {contrato.Funcionario.Endereco.Localidade}, {contrato.Funcionario.Endereco.UF}.

Pelo presente instrumento particular de contrato individual de trabalho, fica justo e contratado o seguinte:

Cláusula 1ª - O EMPREGADO prestará ao EMPREGADOR, a partir de {contrato.Inicio} e assinatura deste instrumento, seus trabalhos exercendo a função de {contrato.Cargo}, prestando pessoalmente o labor diário no período compreendido entre 9 horas às 18 horas, e intervalo de 1 hora para almoço;

            Cláusula 2ª - Não haverá expediente nos dias de sábado, sendo prestado a compensação de horário semanal;

            Cláusula 3ª - O EMPREGADOR pagará mensalmente, ao EMPREGADO, a título de salário a importância de {contrato.Salario.ToString()} ({contrato.Salario.Extenso()}), com os descontos previstos por lei;

            Cláusula 4ª - Estará o EMPREGADO subordinado a legislação vigente no que diz respeito aos descontos de faltas e demais sanções disciplinares contidas na Consolidação das Leis do Trabalho.

            Cláusula 5ª - O prazo de duração do contrato é de 2(dois) anos, contados a partir da assinatura pelos contratantes;

            Cláusula 6ª - O EMPREGADO obedecerá o regulamento interno da empresa, e filosofia de trabalho da mesma.

Como prova do acordado, assinam instrumento, afirmado e respeitando seu teor por inteiro, e firmam conjuntamente a este duas testemunhas, comprovando as razões descritas.

{contrato.Empresa.Endereco.Localidade}, {DateTime.Today.ToString("D")}


_______________________________________________________
{contrato.Empresa.RazaoSocial}

_______________________________________________________
{contrato.Funcionario.Nome}

_______________________________________________________
(Nome, R.G, Testemunha)

_______________________________________________________
(Nome, R.G, Testemunha)";

            Console.WriteLine(documento);
        }
    }
}