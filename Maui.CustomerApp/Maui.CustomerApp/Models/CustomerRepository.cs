using Maui.CustomerApp.CustomerViews;

namespace Maui.CustomerApp.Models
{
    public class CustomerRepository
    {
        public static List<Customer> CustomerList = new List<Customer>()
        {
            new Customer() { Id = 1, Name = "leila tayeb", Address = "Str. 112", Email = "tayeb@gmail.com", PhoneNumber = 01470258803},
            new Customer() { Id = 2, Name = "siham lil", Address = "Str. 114", Email = "siham@gmail.com", PhoneNumber = 78966555},
            new Customer() { Id = 3, Name = "Jawad nahar", Address = "Str. 117", Email = "Jawad@gmail.com", PhoneNumber = 45877522},
            new Customer() { Id = 4, Name = "iman sidiq", Address = "Str. 142", Email = "iman@gmail.com", PhoneNumber = 01225477},
            new Customer() { Id = 5, Name = "abdelouahed salim", Address = "Str. 8112", Email = "abdelouahed@gmail.com", PhoneNumber = 6355897},
            new Customer() { Id = 6, Name = "mahfoud leil", Address = "Str. 1192", Email = "mahfoud@gmail.com", PhoneNumber = 45336987},
            new Customer() { Id = 7, Name = "iman ghouziyel", Address = "Str. 1125", Email = "ghouziyel@gmail.com", PhoneNumber = 1245789},
            
        };

        // CRUD Operation : Create, Read, Update & Delete

        //Create
        public static void CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                //get and set customer Id
                int maxId = CustomerList.Max(x => x.Id);
                customer.Id = maxId + 1;

                var checkEmailandPhone = CustomerList.Where(x => x.Email.ToLower().Equals(customer.Email.ToLower()) || x.PhoneNumber == customer.PhoneNumber).FirstOrDefault();
                if (checkEmailandPhone != null)
                {
                    Shell.Current.DisplayAlert("Error", "Email or Phone Number cannot be used", "Ok");
                    return;
                }
                CustomerList.Add(customer);
                Shell.Current.DisplayAlert("Success", "Customer Created Done", "Ok");
                Shell.Current.GoToAsync($"//{nameof(Customerwebpage)}");
            }
        }


        //Read All
        public static List<Customer> GetAllCustomers() => CustomerList;

        //Read Individual
        public static Customer GetCustomerById(int id)
        {
            var customer = CustomerList.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        //Update
        public static void UpdateCustomer(Customer customer)
        {
            var result = CustomerList.FirstOrDefault(x => x.Id == customer.Id);
            if (result != null)
            {
                result.Name = customer.Name;
                result.Email = customer.Email;
                result.Address = customer.Address;
                result.PhoneNumber = customer.PhoneNumber;
                Shell.Current.DisplayAlert("Success", "Customer Updated", "Ok");
                Shell.Current.GoToAsync($"//{nameof(Customerwebpage)}");
            }
        }

        //Delete
        public static void DeleteCustomer(int id)
        {
            var result = CustomerList.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                CustomerList.Remove(result);
                Shell.Current.DisplayAlert("Success", "Customer Deleted", "Ok");
                Shell.Current.GoToAsync($"//{nameof(Customerwebpage)}");
            }
        }


        //Search
        public static List<Customer> SearchCustomer(string filter)
        {
            var customers = CustomerList.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            if (customers == null || customers.Count <= 0)
            {
                customers = CustomerList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else return customers;

            if (customers == null || customers.Count <= 0)
            {
                customers = CustomerList.Where(x => x.PhoneNumber == int.Parse(filter)).ToList();
            }
            else return customers;

            return customers;
        }
    }
}
