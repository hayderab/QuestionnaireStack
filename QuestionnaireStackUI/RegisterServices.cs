namespace QuestionnaireStackUI
{
    public static class RegisterServices
    {

        public static void ConfigureServices(this WebApplicationBuilder builder) // extension method
        {   // dependency injection
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // caching 
            builder.Services.AddMemoryCache();

        }
    }
}
