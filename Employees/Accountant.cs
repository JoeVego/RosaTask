using FirstApp.Requests;

namespace FirstApp.Employees
{
    /// <summary>
    /// Класс Бухгалтера.
    /// </summary>
    internal class Accountant(string firstName, EmployeePositions position) : Employee(firstName, position)
    {
        static string InputString()
        {
            while (true)
            {
                Console.Write("Ввод = ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова");
                }
            }
        }


        public void ChangeReqState(IRequestState currentReqStatus, Employee accEmpl,
            int reqId)
        {
            if (currentReqStatus is NewRequest)
            {
                Console.WriteLine("\nЕсли вы хотите перевести заявку в статус В работе," +
                    "введите Да");
                string answer = InputString();

                if (answer.Equals("Да"))
                {
                    currentReqStatus.TakeToWork(accEmpl.GetEmployeeRequests()[reqId]);
                }
                else
                    Console.WriteLine("\nВведен неверный ответ. Статус заявки не изменился");
            }
            else if (currentReqStatus is RequestInProcess)
            {
                Console.WriteLine("\nВведите требуемый статус Завершено или Отклонена");
                string answer = InputString();

                if (answer.Equals("Завершено"))
                {
                    currentReqStatus.Complete(accEmpl.GetEmployeeRequests()[reqId]);
                }
                else if (answer.Equals("Отклонена"))
                {
                    currentReqStatus.Reject(accEmpl.GetEmployeeRequests()[reqId]);
                }
                else
                    Console.WriteLine("\nВведен неверный ответ. Статус заявки не изменился");
            }
            else if (currentReqStatus is RejectedRequest)
            {
                Console.WriteLine("\nЕсли вы хотите вернуть заявку в статус В работе," +
                    "введите Да");
                string answer = InputString();
                if (answer.Equals("Да"))
                {
                    currentReqStatus.TakeToWork(accEmpl.GetEmployeeRequests()[reqId]);
                }
                else
                    Console.WriteLine("\nВведен неверный ответ. Статус заявки не изменился");
            }
        }
    }
}
