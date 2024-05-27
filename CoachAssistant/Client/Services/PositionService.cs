using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class PositionService
    {
        private readonly IHttpClientService httpClientService;

        public List<PositionViewModel> Positions { get; private set; } = new();

        public PositionService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task GetAll() =>
            Positions = await httpClientService.GetAsync<List<PositionViewModel>>(ApiUrls.PositionsUrl);
    }
}
