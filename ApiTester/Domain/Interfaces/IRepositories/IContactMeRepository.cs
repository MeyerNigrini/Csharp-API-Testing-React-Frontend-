using ApiTester.Domain.Entities;

namespace ApiTester.Domain.Interfaces.IRepositories
{
    // IContactMeRepository defines the contract for interacting with the contact data in the repository
    // This interface abstracts the operations related to the 'ContactMe' data, so the service layer
    // doesn't need to know how the data is stored or retrieved.
    public interface IContactMeRepository
    {
        // This method is responsible for adding a new contact to the database
        // It takes a ContactMeModel object as input, which represents a new contact to be saved
        // The method is asynchronous because it involves database operations (I/O-bound)
        // It returns a Task, which allows us to await its completion
        Task AddContactAsync(ContactMeEntity contact);
    }
}
