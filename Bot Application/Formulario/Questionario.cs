using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot_Application.Formulario
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Desculpe, não entendi \"{0}\".")]
    public class Questionario
    {
        [Template(TemplateUsage.EnumSelectOne, "Abrir um vidro novo ou com a tampa muito apertada {||}")]
        public AbrirVidro AbrirVidro { get; set; }

        [Template(TemplateUsage.EnumSelectOne, "Escrever {||}")]
        public Escrever Escrever { get; set; }

        [Template(TemplateUsage.EnumSelectOne, "Virar uma chave {||}")]
        public VirarChave VirarChave { get; set; }

        public static IForm<Questionario> BuildForm()
        {
            var form = new FormBuilder<Questionario>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "sim", "yes", "s", "yep" };
            form.Configuration.No = new string[] { "não", "nao", "no", "n" };
            form.Message("Meça a sua habilidade em fazer as seguintes atividades na semana passada escolhendo a resposta apropriada.");
            form.OnCompletion(async (context, questionario) => {
                // Salvar na base de dados
                // Gerar pedido
                // Integrar com serviço xpto
                await context.PostAsync("O relatório foi gerado.");
            });

            return form.Build();
        }
    }
    
    public enum AbrirVidro
    {
        [Terms("Não houve dificuldade")]
        [Describe("Não houve dificuldade")]
        NaoHouveDificuldade = 1,

        [Terms("Houve pouca dificuldade")]
        [Describe("Houve pouca dificuldade")]
        HouvePoucaDificuldade,

        [Terms("Houve dificuldade média")]
        [Describe("Houve dificuldade média")]
        HouveDificuldadeMedia,

        [Terms("Houve muita dificuldade")]
        [Describe("Houve muita dificuldade")]
        HouveMuitaDificuldade,

        [Terms("Não conseguiu fazer")]
        [Describe("Não conseguiu fazer")]
        NaoConseguiuFazer
    }

    public enum Escrever
    {
        [Terms("Não houve dificuldade")]
        [Describe("Não houve dificuldade")]
        NaoHouveDificuldade = 1,

        [Terms("Houve pouca dificuldade")]
        [Describe("Houve pouca dificuldade")]
        HouvePoucaDificuldade,

        [Terms("Houve dificuldade média")]
        [Describe("Houve dificuldade média")]
        HouveDificuldadeMedia,

        [Terms("Houve muita dificuldade")]
        [Describe("Houve muita dificuldade")]
        HouveMuitaDificuldade,

        [Terms("Não conseguiu fazer")]
        [Describe("Não conseguiu fazer")]
        NaoConseguiuFazer
    }

    public enum VirarChave
    {
        [Terms("Não houve dificuldade")]
        [Describe("Não houve dificuldade")]
        NaoHouveDificuldade = 1,

        [Terms("Houve pouca dificuldade")]
        [Describe("Houve pouca dificuldade")]
        HouvePoucaDificuldade,

        [Terms("Houve dificuldade média")]
        [Describe("Houve dificuldade média")]
        HouveDificuldadeMedia,

        [Terms("Houve muita dificuldade")]
        [Describe("Houve muita dificuldade")]
        HouveMuitaDificuldade,

        [Terms("Não conseguiu fazer")]
        [Describe("Não conseguiu fazer")]
        NaoConseguiuFazer
    }
}