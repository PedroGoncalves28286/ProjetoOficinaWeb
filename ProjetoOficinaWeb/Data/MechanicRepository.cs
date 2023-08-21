using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class MechanicRepository : GenericRepository<Mechanic>,IMechanicRepository
    {
        public MechanicRepository(DataContext context) : base(context)
        {


        }
        
             
        
    }
}
