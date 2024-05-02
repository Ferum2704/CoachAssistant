using Infrastructure.Identity;
using Microsoft.Extensions.Options;

namespace CoachAssistant.Server.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "JwtSettings";

        private readonly IConfiguration configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            configuration.GetSection(SectionName).Bind(options);
        }
    }
}
