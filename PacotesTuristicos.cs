using System;

namespace AT02_RafaelOlivato_UC04.Models
{
    public class PacotesTuristicos
    {
        public int IdPacotesTuristicos {get;set;}
        public string Nome {get;set;}
        public string Origem{get;set;}
        public string Destino {get;set;}
        public string Atrativos {get;set;}
        public DateTime Saida {get;set;}
        public DateTime Retorno {get;set;}
        
    }
}