using JC_BlueTec.Infra.Models;
using JC_BlueTec.Domain.Entidades;

namespace JC_BlueTec.Infra.Interfaces
{
    public interface IClienteRepository : IGenericRepository
{
    Task<PageList<Cliente>> GetAllAsync(PageParams pageParams);
    Task<Cliente> GetByIdAsync(int Id);
    Task<Cliente> GetByNameAsync(string name);

}
}