using Asal.OrderManagementSystem.Api.Interfaces;
using Asal.OrderManagementSystem.Api.Models;

namespace Asal.OrderManagementSystem.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new()
    {
        new Customer
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Ahmad Ali",
            Email = "ahmad@gmail.com"
        },
        new Customer
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Omar Khalil",
            Email = "omar@gmail.com"
        },
        new Customer
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Sara Hassan",
            Email = "sara@gmail.com"
        }
    };
        public Guid? CreateCustomer(string customerName, string customerEmail)
        {
            if (string.IsNullOrEmpty(customerName))
                throw new ArgumentNullException(nameof(customerName),"Customer name cannot be empty.");

            if (string.IsNullOrEmpty(customerEmail))
                throw new ArgumentNullException(nameof(customerEmail), "Customer Email cannot be empty.");


            foreach (var customer in _customers)
            {
                if(customer.Email == customerEmail)
                        throw new ArgumentException("two customers can't have the same email");

            }
            var newCustomer = new Customer {
                Id=Guid.NewGuid(),
                Email = customerEmail,
                Name=customerName
            };
            _customers.Add(newCustomer);
            return newCustomer.Id;
        }

        public bool DeleteCustomerById(Guid customerId)
        {
            var customer=GetCustomerById(customerId);
            if (customer is null)
                return false;
            else
            {
                _customers.Remove(customer);
                return true;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers.ToList();
        }

        public Customer? GetCustomerById(Guid customerId)
        {
            return _customers.FirstOrDefault(c=>c.Id== customerId);
        }

        public bool UpdateCustomer(Guid customerId, string? customerName, string? customerEmail)
        {
            var customer= GetCustomerById(customerId);
            if (customer is null)
                return false;
            if (customerEmail is not null)
            {
                foreach (var customer1 in _customers)
                    if (customer1.Email == customerEmail)
                        throw new InvalidOperationException("two customers can't have the same email");

                customer.Email = customerEmail;
            }
            if (customerName is not null)
                customer.Name= customerName;
           
            return true;

        }
    }
}
