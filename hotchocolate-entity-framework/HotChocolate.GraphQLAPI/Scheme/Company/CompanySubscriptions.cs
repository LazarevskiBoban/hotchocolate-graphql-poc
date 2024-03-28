using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace HotChocolate.GraphQLAPI.Scheme.Company
{
    [ExtendObjectType(typeof(BaseSubscription))]
    public class CompanySubscriptions
    {
        [Subscribe]
        [Topic("CompanyHasBeenCreated")]
        public CompanyDTO CompanyHasBeenCreated([EventMessage] CompanyDTO company) => company;

        [Subscribe]
        public ValueTask<ISourceStream<CompanyDTO>> CompanyHasBeenUpdated(
            [EventMessage] CompanyDTO company,
            [Service] ITopicEventReceiver receiver)
        {
            return receiver.SubscribeAsync<CompanyDTO>($"{CompanyHasBeenUpdated}_{company.Id}");
        }
    }
}