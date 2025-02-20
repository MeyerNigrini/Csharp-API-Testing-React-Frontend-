using Domain.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    /// <summary>
    /// Repository class responsible for handling ContactMe data operations.
    /// Provides methods to interact with the ContactMe table in the database.
    /// </summary>
    public class ContactMeRepository : IContactMeRepository
    {
        private readonly AppDbContext _context; // The EF DbContext for database access

        /// <summary>
        /// Constructor for ContactMeRepository.
        /// Initializes the repository with the database context.
        /// </summary>
        /// <param name="context">Database context for accessing ContactMe data.</param>
        public ContactMeRepository(AppDbContext context)
        {
            _context = context; // Store the DbContext for use in repository methods
        }

        /// <summary>
        /// Asynchronously adds a new contact entry to the database.
        /// </summary>
        /// <param name="contact">The contact entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddContactAsync(ContactMeEntity contact)
        {
            // Add the contact entity to the DbSet for tracking.
            await _context.ContactMe.AddAsync(contact);

            // Save changes to persist the new contact entry in the database.
            await _context.SaveChangesAsync();
        }
    }
}
