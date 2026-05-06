using Microsoft.EntityFrameworkCore;
using CustomersCRUD.Data;
using CustomersCRUD.Models;

namespace CustomersCRUD.Repositories
{
    public class CustomersRepository 
    {
        private readonly AppDbContext _context;

        public CustomersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateAsync(int id, Customer customer)
        {
            var existing = await _context.Customers.FindAsync(id);
            if ( existing == null)
            return false;

            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.Email = customer.Email;
            existing.DateOfBirth = customer.DateOfBirth;
            existing.Age = customer.Age;
            existing.Gender = customer.Gender;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            return false;
            

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}