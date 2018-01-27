using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Bot_Application.Dialogs
{
    [Serializable]
    public class QnaDialog : QnAMakerDialog
    {
        public QnaDialog() : base(new QnAMakerService(new QnAMakerAttribute(            ConfigurationManager.AppSettings["QnaSubscriptionKey"],             ConfigurationManager.AppSettings["QnaKnowledgebaseId"],             "Não, encontrei sua resposta",0.5)))        {

        }
    }
}