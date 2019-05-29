using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AsyncRefactoringBug
{
    public class SomeOtherRequest : IRequest
    {
    }

    public class SomeOtherRequestHandler: IRequestHandler<SomeOtherRequest>
    {
        public Task<Unit> Handle(SomeOtherRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
