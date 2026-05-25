using FirstApp.Requests;

namespace FirstApp.Employees
{
    /// <summary>
    /// Класс Бухгалтера
    /// </summary>
    internal class Accountant(string firstName, EmployeePositions position) : Employee(firstName, position)
    {

        private void GetRequestInfo(Employee employee) 
        {
            int counter = 0;
            List<Request> employeeRequests = employee.GetEmployeeRequests();

            Console.WriteLine($"Справки запрошенные сотрудником {firstName}: ");
            foreach (Request certReq in certRequests)
            {
                Console.WriteLine($"{counter}. " + certReq);
            }

            Console.WriteLine("Введите номер справки для получения сведений = ");
            int searchId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(employeeRequests[searchId]);
        }
    }
}
