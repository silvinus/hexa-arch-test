using HexaArch.Domain.ValueObject;

namespace HexaArch.Application.Commands.RegisterContract
{
    public interface IRegisterUseCase
    {
        Task<RegisterResults> Execute(Supplier supplier, string contractName, DateOnly interventionDate, float price, float tva);
    }
}
