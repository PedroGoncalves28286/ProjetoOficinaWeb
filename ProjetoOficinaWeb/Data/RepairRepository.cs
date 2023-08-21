using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class RepairRepository :GenericRepository<Repair>, IRepairRepository
    {
        public RepairRepository(DataContext context) : base(context)
        {

        }

    }
}
