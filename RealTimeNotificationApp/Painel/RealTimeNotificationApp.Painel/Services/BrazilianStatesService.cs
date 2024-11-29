using RealTimeNotificationApp.Painel.Models;

namespace RealTimeNotificationApp.Painel.Services
{
    public class BrazilianStatesService
    {
        public static List<BrazilianStateModel> GetEstados()
        {
            var listaEstados = new List<BrazilianStateModel>()
            {
                new BrazilianStateModel(){ Abreviation="AC", Name="Acre"},
                new BrazilianStateModel(){ Abreviation="AL", Name="Alagoas"},
                new BrazilianStateModel(){ Abreviation="AP", Name="Amapá"},
                new BrazilianStateModel(){ Abreviation="AM", Name="Amazonas"},
                new BrazilianStateModel(){ Abreviation="BA", Name="Bahia"},
                new BrazilianStateModel(){ Abreviation="CE", Name="Ceará"},
                new BrazilianStateModel(){ Abreviation="DF", Name="Distrito Federal"},
                new BrazilianStateModel(){ Abreviation="ES", Name="Espírito Santo"},
                new BrazilianStateModel(){ Abreviation="GO", Name="Goiás"},
                new BrazilianStateModel(){ Abreviation="MA", Name="Maranhão"},
                new BrazilianStateModel(){ Abreviation="MT", Name="Mato Grosso"},
                new BrazilianStateModel(){ Abreviation="MS", Name="Mato Grosso do Sul"},
                new BrazilianStateModel(){ Abreviation="MG", Name="Minas Gerais"},
                new BrazilianStateModel(){ Abreviation="PA", Name="Pará"},
                new BrazilianStateModel(){ Abreviation="PB", Name="Paraíba"},
                new BrazilianStateModel(){ Abreviation="PR", Name="Paraná"},
                new BrazilianStateModel(){ Abreviation="PE", Name="Pernambuco"},
                new BrazilianStateModel(){ Abreviation="PI", Name="Piauí"},
                new BrazilianStateModel(){ Abreviation="RJ", Name="Rio de Janeiro"},
                new BrazilianStateModel(){ Abreviation="RN", Name="Rio Grande do Norte"},
                new BrazilianStateModel(){ Abreviation="RS", Name="Rio Grande do Sul"},
                new BrazilianStateModel(){ Abreviation="RO", Name="Rondônia"},
                new BrazilianStateModel(){ Abreviation="RR", Name="Roraima"},
                new BrazilianStateModel(){ Abreviation="SC", Name="Santa Catarina"},
                new BrazilianStateModel(){ Abreviation="SP", Name="São Paulo"},
                new BrazilianStateModel(){ Abreviation="SE", Name="Sergipe"},
                new BrazilianStateModel(){ Abreviation="TO", Name="Tocantins"}
            };
            return listaEstados;
        }
    }
}
