using FirstApp.Certificates;
using FirstApp.Employees;
using FirstApp.Requests;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Добро пожаловать в сервис справок сотрудников." +
            "выберите действие:\n1.Создать сотрудника\n2.Войти в профиль сотрудника");
            int mainMenu = Convert.ToInt32(Console.ReadLine());

            if (mainMenu == 1)
            {
                Console.WriteLine("Введите имя сотрудника: ");
                string fNameInput = Console.ReadLine();

                Console.WriteLine("Выберите должность сотрудника :" +
                    "\n0. Бухгалтер\n1. Разработчик");
                int createEmployeePos = Convert.ToInt32(Console.ReadLine());

                if (createEmployeePos == 0)
                {
                    employees.Add(new Accountant(fNameInput, EmployeePositions.Accountant));
                }
                else if (createEmployeePos == 1)
                {
                    employees.Add(new Programmer(fNameInput, EmployeePositions.Programmer));
                }
                else
                {
                    Console.WriteLine($"Ошибка создания сотрудника с именем {fNameInput}");
                }

            }
            else if (mainMenu == 2)
            {
                int counter = 0;
                Console.WriteLine("Список сотрудников:");
                foreach (Employee empl in employees)
                {
                    Console.WriteLine($"{counter}" + empl);
                    counter++;
                }

                Console.WriteLine("Введите номер выбранного сотрудника:");
                int emplIdx = Convert.ToInt32(Console.ReadLine());
                Employee currentEmpl = employees[emplIdx];

                if (currentEmpl.position == EmployeePositions.Programmer)
                {
                    Console.WriteLine($"Cотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Заказать справку" +
                        $"\n2.Получить информацию о заказаханных справках" +
                        $"\nВведите номер выбранной операции:");

                    int progOperation = Convert.ToInt32(Console.ReadLine());
                    if (progOperation == 1)
                    {
                        Console.WriteLine($"Введите тип требуемой справки(2-НДФЛ,по месту работу, средний доход," +
                            $"свободной формы) :");
                        string reqCertType = Console.ReadLine();
                        CertificateTypes newCertType;
                        switch (reqCertType)
                        {
                            case "2-НДФЛ": newCertType = CertificateTypes.NDFL2;
                                break;
                            case "по месту работы":
                                newCertType = CertificateTypes.JobPlace;
                                break;
                            case "средний доход":
                                newCertType = CertificateTypes.AverageIncome;
                                break;
                            case "свободной формы":
                                newCertType = CertificateTypes.FreeType;
                                break;
                            default: Console.WriteLine("Указан несуществующий тип справки");
                                throw new Exception("Пока не обработал неверный тип справки :С");
                        }

                        Console.WriteLine($"Введите кол-во справок для заказа :");
                        int reqCertAmount = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Введите причину заказа справки");
                        string reqCertReason = Console.ReadLine();

                        currentEmpl.RequestCertificate(newCertType, reqCertAmount, reqCertReason);
                    }
                    if (progOperation == 2)
                    {
                        Console.WriteLine($"Список справок сотрудника {currentEmpl.GetName} :");
                        foreach(Request req in currentEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine(req);
                        }
                    }
                }
                else if (currentEmpl.position == EmployeePositions.Accountant)
                {
                    Console.WriteLine($"Cотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Посмотреть детали запроса" +
                        $"\n2.Изменить статус запроса" +
                        $"\nВведите номер выбранной операции:");

                    int accOperation = Convert.ToInt32(Console.ReadLine());
                    if (accOperation == 1)
                    {
                        Console.WriteLine("Список сотрудников:");
                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("Введите номер нужного сотрудника = ");
                        int accEmplIdx = Convert.ToInt32(Console.ReadLine());
                        Employee accEmpl = employees[accEmplIdx];


                        Console.WriteLine($"Сотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }
                        
                        Console.WriteLine("Введите номер справки = ");
                        int reqId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Информация по справке :" +
                            $"\n{accEmpl.GetEmployeeRequests()[reqId]}");
                    }
                    if (accOperation == 2)
                    {
                        Console.WriteLine("Список сотрудников:");
                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("Введите номер нужного сотрудника = ");
                        int accEmplIdx = Convert.ToInt32(Console.ReadLine());
                        Employee accEmpl = employees[accEmplIdx];


                        Console.WriteLine($"Сотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }

                        Console.WriteLine("Введите номер справки = ");
                        int reqId = Convert.ToInt32(Console.ReadLine());

                        IRequestState currentReqStatus = accEmpl.GetEmployeeRequests()[reqId].GetCertStatus();

                        Console.WriteLine($"Справка имеет статус = " +
                            $" {accEmpl.GetEmployeeRequests()[reqId].GetCertStatusName()}");

                        if (currentReqStatus is NewRequest)
                        {
                            Console.WriteLine("Если вы хотите перевести заявку в статус В работе," +
                                "введите Да");
                            string answer = Console.ReadLine();
                            if (answer.Equals("Да"))
                            {
                                currentReqStatus.TakeToWork(accEmpl.GetEmployeeRequests()[reqId]);
                            }
                            else
                                Console.WriteLine("Введен неверный ответ. Статус заявки не изменился");
                        }
                        else if (currentReqStatus is RequestInProcess)
                        {
                            Console.WriteLine("Введите требуемый статус Завершено или Отклонена");
                            string answer = Console.ReadLine();
                            if (answer.Equals("Завершено"))
                            {
                                currentReqStatus.Complete(accEmpl.GetEmployeeRequests()[reqId]);
                            }
                            else if (answer.Equals("Отклонена"))
                            {
                                currentReqStatus.Reject(accEmpl.GetEmployeeRequests()[reqId]);
                            }
                            else
                                Console.WriteLine("Введен неверный ответ. Статус заявки не изменился");
                        }
                        else if (currentReqStatus is RejectedRequest)
                        {
                            Console.WriteLine("Если вы хотите вернуть заявку в статус В работе," +
                                "введите Да");
                            string answer = Console.ReadLine();
                            if (answer.Equals("Да"))
                            {
                                currentReqStatus.TakeToWork(accEmpl.GetEmployeeRequests()[reqId]);
                            }
                            else
                                Console.WriteLine("Введен неверный ответ. Статус заявки не изменился");
                        }
                    }
                 }
            }
        }
     }
}