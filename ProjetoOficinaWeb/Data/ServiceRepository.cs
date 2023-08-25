using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class ServiceRepository :GenericRepository<Service> , IServiceRepository 
    {
        

        public ServiceRepository(DataContext context) : base(context)
        {
           
        }
    }
}
