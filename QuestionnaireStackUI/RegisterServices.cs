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
            builder.Services.AddSingleton<IDbconnection, Dbconnection>();
            builder.Services.AddSingleton<ICategoryData, MongoCategoryData>();
            builder.Services.AddSingleton<IStatusData, MongoStatusData>();
            builder.Services.AddSingleton<IUserData, MongoUserData>();
            builder.Services.AddSingleton<IQuestionnaireData, MongoQuestionnaireData>();





        }
    }
}
