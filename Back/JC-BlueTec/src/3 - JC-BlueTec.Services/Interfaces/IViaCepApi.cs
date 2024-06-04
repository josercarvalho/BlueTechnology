using JC_BlueTec.Services.DTO;
using JC_BlueTec.Domain.Entidades;

namespace JC_BlueTec.Services.Interfaces
{
    public interface IViaCepApi
    {
        Task<ResponseGenerico<Endereco>> BuscarPorCodigo(string cep);
    }
}