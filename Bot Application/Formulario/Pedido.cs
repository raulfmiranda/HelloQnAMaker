using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;

namespace Bot_Application.Formulario
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Desculpe, não entendi \"{0}\".")]
    public class Pedido
    {
        // Solicitações de informações vão seguir a sequência abaixo: Salgadinhos, Bebidas...
        public Salgadinhos Salgadinhos { get; set; }
        public Bebidas Bebidas { get; set; }
        public TipoEntrega TipoEntrega { get; set; }
        public CPFNaNota CPFNaNota { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public static IForm<Pedido> BuildForm()
        {
            var form = new FormBuilder<Pedido>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "sim", "yes", "s", "yep" };
            form.Configuration.No = new string[] { "não", "nao", "no", "n" };
            form.Message("Olá, seja bem-vindo. Será um prazer atender você.");
            form.OnCompletion(async (context, pedido) => {
                // Salvar na base de dados
                // Gerar pedido
                // Integrar com serviço xpto
                await context.PostAsync("Seu pedido número 123456 foi gerado e em instantes será entregue.");
            });

            return form.Build();
        }
    }

    [Describe("Tipo de Entrega")]
    public enum TipoEntrega
    {
        [Terms("Retirar No Local", "Passo ai", "Eu pego ai", "Retiro ai")]
        [Describe("Retirar No Local")]
        RetirarNoLocal = 1,                 // Só mostra a partir do índice 1 = pode digitar 1 para escolher

        [Terms("Motoboy", "Motoca", "Cachorro loco")]
        [Describe("Motoboy")]
        Motoboy
    }

    public enum Salgadinhos
    {
        [Terms("Esfirra", "Esfira", "Isfira", "i")]
        [Describe("Esfirra")]
        Esfirra = 1,                        // Só mostra a partir do índice 1 = pode digitar 1 para escolher

        [Terms("Quibe", "Kibe", "k", "q")]
        [Describe("Quibe")]
        Quibe,

        [Terms("Coxinha", "Cochinha", "coxa", "c")]
        [Describe("Coxinha")]
        Coxinha
    }

    public enum Bebidas
    {
        [Terms("Água", "agua", "h2o", "a")]
        [Describe("Água")]
        Agua = 1,                           // Só mostra a partir do índice 1 = pode digitar 1 para escolher

        [Terms("Refrigerante", "refri", "r")]
        [Describe("Refrigerante")]
        Refrigerante,

        [Terms("Suco", "suco", "s")]
        [Describe("Suco")]
        Suco
    }

    [Describe("CPF na Nota")]
    public enum CPFNaNota
    {
        [Terms("Sim", "s", "yep")]
        [Describe("Sim")]
        Sim = 1,

        [Terms("Não", "nao", "n")]
        [Describe("Não")]
        Nao
    }
}