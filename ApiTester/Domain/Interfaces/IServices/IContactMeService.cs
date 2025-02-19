using ApiTester.Application.DTOs;

namespace ApiTester.Domain.Interfaces.IServices
{
    // IContactMeService defines the contract for the service layer, which contains business logic
    // The service layer coordinates the interaction between the controller and the repository layers.
    // It is responsible for validating, processing, and executing business logic, and making calls to repositories.
    public interface IContactMeService
    {
        // This method is responsible for creating a new contact based on the provided data transfer object (DTO)
        // The method takes a ContactMeDto object as input, which represents the contact data to be processed
        // The method returns a Task that can be awaited. It returns a boolean indicating the success of the operation
        Task<bool> CreateContactAsync(ContactMeDto contactDto);
    }
}
