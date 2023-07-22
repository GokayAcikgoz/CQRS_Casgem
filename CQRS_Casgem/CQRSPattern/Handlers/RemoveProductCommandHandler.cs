using CQRS_Casgem.CQRSPattern.Commands;
using CQRS_Casgem.DAL;

namespace CQRS_Casgem.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context __context;

        public RemoveProductCommandHandler(Context context)
        {
            __context = context;
        }

        public void Handle(RemoveProductCommand command)
        {
            var values = __context.Products.Find(command.Id);
            __context.Products.Remove(values);
            __context.SaveChanges();
        }
    }
}
