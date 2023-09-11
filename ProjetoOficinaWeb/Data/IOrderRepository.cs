using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName);

        Task AddItemToOrderAsync(AddItemViewModel model, string userName);

        Task ModifyOrderDetailTempAsync(int id, double quantity);

        Task DeleteDetailTempAsync(int id);

        Task<bool> ConfirmOrderAsync(string userName);

        Task<Order> GetOrderAsync(int id);

        Task RepairOrder(RepairViewModel model);

        

        Task RecoverPasswordViewModel(RecoverPasswordViewModel model);

        

        Task RecoverPasswordViewModel(RecoverPasswordViewModel model, string password); 

        Task DeliverOrder(DeliveryViewModel model);
       
    }
        
}
