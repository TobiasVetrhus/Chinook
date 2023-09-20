namespace Chinook.Models
{
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Gets or sets the postal code of the customer.
        /// </summary>
        public string PostalCode { get; set; } = null!;

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; } = null!;
    }
}

