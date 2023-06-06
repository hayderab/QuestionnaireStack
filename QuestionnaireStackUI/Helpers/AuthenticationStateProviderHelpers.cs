using Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
using Microsoft.AspNetCore.Components.Authorization;

namespace QuestionnaireStackUI.Helpers
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<UserModal> GerUserFromAuth(this AuthenticationStateProvider provider, IUserData userData)
        {

            var authSate = await provider.GetAuthenticationStateAsync();
            string objectId = authSate.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return  await userData.GetUserFromAuthentication(objectId);
        }

    }
}
