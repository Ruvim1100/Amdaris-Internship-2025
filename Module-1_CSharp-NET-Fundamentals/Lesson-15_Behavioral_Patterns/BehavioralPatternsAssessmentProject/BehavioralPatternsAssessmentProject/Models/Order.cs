using BehavioralPatternsAssessmentProject.Abstraction;

namespace BehavioralPatternsAssessmentProject.Models
{
    internal class Order : ISubject
    {

        private readonly List<IObserver> observers = new();
        private readonly List<Customer> customers = new();
        private readonly List<Staff> staffMembers = new();

        public string Book { get; }
        public OrderStatus Status { get; private set; }

        public IReadOnlyList<Customer> Customers => customers;
        public IReadOnlyList<Staff> StaffMembers => staffMembers;

        public Order(string title)
        {
            Book = title;
            Status = OrderStatus.Created;
        }

        public void AddCustomer(Customer customer) => customers.Add(customer);
        public void AddStaff(Staff staff) => staffMembers.Add(staff);
        public void RemoveStaff(Staff staff) => staffMembers.Remove(staff);

        public void Attach(IObserver observer) => observers.Add(observer);
        public void Detach(IObserver observer) => observers.Remove(observer);

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Notify();
        }
    }
}
