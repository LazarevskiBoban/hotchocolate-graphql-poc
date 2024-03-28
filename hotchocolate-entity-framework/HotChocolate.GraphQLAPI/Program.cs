using DataAnnotatedModelValidations;
using HotChocolate.GraphQLAPI.Registrations;
using HotChocolate.GraphQLAPI.Scheme;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterAutoMapper();
builder.RegisterContext();
builder.RegisterServices();
builder.RegisterRepositories();
builder.RegisterDataLoaders();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BaseQuery>()
    .AddMutationType<BaseMutation>()
    .AddSubscriptionType<BaseSubscription>()
    .AddExtendedQueryTypes()
    .AddExtendedMutationTypes()
    .AddExtendedSubscriptionTypes()
    .AddInMemorySubscriptions()
    .AddDataAnnotationsValidator()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();