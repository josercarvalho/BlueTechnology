using JC_BlueTec.Services.DTO;
using JC_BlueTec.Infra.Models;

namespace JC_BlueTec.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddClientes(ClienteDTO model);
        Task<ClienteDTO> UpdateCliente(int Id, ClienteDTO model);
        Task<bool> DeleteCliente(int Id);
        Task<ClienteDTO> GetClienteByIdAsync(int Id);
        Task<PageList<ClienteDTO>> GetAllClientesAsync(PageParams pageParams);
    }
}