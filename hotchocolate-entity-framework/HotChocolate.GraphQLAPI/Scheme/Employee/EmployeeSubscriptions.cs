using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace HotChocolate.GraphQLAPI.Scheme.Employee
{
    [ExtendObjectType(typeof(BaseSubscription))]
    public class EmployeeSubscriptions
    {
        [Subscribe]
        [Topic("EmployeeHasBeenCreated")]
        public EmployeeDTO EmployeeHasBeenCreated([EventMessage] EmployeeDTO employee) => employee;

        [Subscribe]
        [Topic("EmployeeHasBeenUpdated")]
        public ValueTask<ISourceStream<EmployeeDTO>> EmployeeHasBeenUpdated(
            [EventMessage] EmployeeDTO employee,
            [Service] ITopicEventReceiver receiver)
        {
            return receiver.SubscribeAsync<EmployeeDTO>($"{EmployeeHasBeenUpdated}_{employee.Id}");
        }
    }
}