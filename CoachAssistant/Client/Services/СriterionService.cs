using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class CriterionService
    {
        private readonly IHttpClientService httpClientService;

        public List<CriterionViewModel> Criteria { get; private set; } = new();


        public CriterionService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task GetAll() =>
            Criteria = await httpClientService.GetAsync<List<CriterionViewModel>>(ApiUrls.CriteriaUrl);
    }
}
