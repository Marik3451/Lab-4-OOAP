using System;

// Інтерфейс для реалізації Bridge
interface IPaymentSystem
{
    void ProcessPayment();
}

class HourlyPayment : IPaymentSystem
{
    public void ProcessPayment()
    {
        Console.WriteLine("Зарплата за годинами обчислена.");
    }
}

class ContractPayment : IPaymentSystem
{
    public void ProcessPayment()
    {
        Console.WriteLine("Зарплата за відрядною формою обчислена.");
    }
}

abstract class Employee
{
    protected IPaymentSystem paymentSystem;

    protected string name;
    protected string position;

    public Employee(string name, string position, IPaymentSystem paymentSystem)
    {
        this.name = name;
        this.position = position;
        this.paymentSystem = paymentSystem;
    }

    public abstract void PaySalary();
}

class RegularEmployee : Employee
{
    public RegularEmployee(string name, string position, IPaymentSystem paymentSystem)
        : base(name, position, paymentSystem)
    {
    }

    public override void PaySalary()
    {
        Console.WriteLine($"Видано зарплату для {position} {name}");
        paymentSystem.ProcessPayment();
    }
}

class Program
{
    static void Main()
    {
        IPaymentSystem hourlyPayment = new HourlyPayment();
        IPaymentSystem contractPayment = new ContractPayment();

        Employee hourlyEmployee = new RegularEmployee("Іван", "Програміст", hourlyPayment);
        Employee contractEmployee = new RegularEmployee("Марія", "Дизайнер", contractPayment);

        hourlyEmployee.PaySalary();
        contractEmployee.PaySalary();
    }
}
