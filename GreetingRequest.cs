using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AsyncRefactoringBug
{
    public class GreetingRequest : IRequest<string>
    {
        public GreetingRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class GreetingRequestHandler : IRequestHandler<GreetingRequest, string>
    {
        public Task<string> Handle(GreetingRequest request, CancellationToken cancellationToken)
        {
            return GetGreeting(request.Name);
        }

        public static Task<string> GetGreeting(string name)
        {
            return Task.FromResult($"Hello, {name ?? "world"}!");
        }
    }
}