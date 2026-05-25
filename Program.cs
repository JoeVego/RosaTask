using FirstApp.Certificates;
using FirstApp.Employees;
using FirstApp.Requests;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool exit = false;
        Console.WriteLine("Добро пожаловать в сервис справок сотрудников.");

        while (!exit)
        {
            Console.WriteLine("\nВыберите действие:\n0.Создать сотрудника" +
            "\n1.Войти в профиль сотрудника\n2.Завершить выполнение программы");
            int mainMenu = Convert.ToInt32(Console.ReadLine());

            if (mainMenu == 0)
            {
                Console.WriteLine("\nВведите имя сотрудника:");
                string fNameInput = Console.ReadLine();

                Console.WriteLine("\nВыберите должность сотрудника:" +
                    "\n0. Бухгалтер\n1. Разработчик");
                int createEmployeePos = Convert.ToInt32(Console.ReadLine());

                if (createEmployeePos == 0)
                {
                    employees.Add(new Accountant(fNameInput, EmployeePositions.Accountant));
                    Console.WriteLine($"Сотрудник {fNameInput} должности бухгалтер создан");
                }
                else if (createEmployeePos == 1)
                {
                    employees.Add(new Programmer(fNameInput, EmployeePositions.Programmer));
                    Console.WriteLine($"Сотрудник {fNameInput} создан");
                }
                else
                {
                    Console.WriteLine($"\nОшибка создания сотрудника с именем {fNameInput}");
                }

            }
            else if (mainMenu == 1)
            {
                int counter = 0;
                Console.WriteLine("\nСписок сотрудников:");
                foreach (Employee empl in employees)
                {
                    Console.WriteLine($"{counter}. " + empl);
                    counter++;
                }

                Console.WriteLine("\nВведите номер выбранного сотрудника:");
                int emplIdx = Convert.ToInt32(Console.ReadLine());
                Employee currentEmpl = employees[emplIdx];

                if (currentEmpl.position == EmployeePositions.Programmer)
                {
                    Console.WriteLine($"\nCотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Заказать справку" +
                        $"\n2.Получить информацию о заказанных справках" +
                        $"\nВведите номер выбранной операции:");

                    int progOperation = Convert.ToInt32(Console.ReadLine());
                    if (progOperation == 1)
                    {
                        Console.WriteLine($"\nВведите тип требуемой справки(2-НДФЛ,по месту работы, средний доход," +
                            $"свободной формы) :");
                        string reqCertType = Console.ReadLine();
                        CertificateTypes newCertType;
                        switch (reqCertType)
                        {
                            case "2-НДФЛ": 
                                newCertType = CertificateTypes.NDFL2;
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
                            default: Console.WriteLine("\nУказан несуществующий тип справки");
                                throw new Exception("Пока не обработал неверный тип справки :С");
                        }

                        Console.WriteLine($"\nВведите кол-во справок для заказа:");
                        int reqCertAmount = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"\nВведите причину заказа справки");
                        string reqCertReason = Console.ReadLine();

                        currentEmpl.RequestCertificate(newCertType, reqCertAmount, reqCertReason);
                    }
                    if (progOperation == 2)
                    {
                        Console.WriteLine($"\nСписок справок сотрудника {currentEmpl.GetName()} :");
                        foreach(Request req in currentEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine(req);
                        }
                    }
                }
                else if (currentEmpl.position == EmployeePositions.Accountant)
                {
                    Console.WriteLine($"\nCотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Посмотреть детали запроса" +
                        $"\n2.Изменить статус запроса" +
                        $"\n3.Заказать справку" +
                        $"\n4.Получить информацию о заказаханных справках" +
                        $"\nВведите номер выбранной операции:");

                    int accOperation = Convert.ToInt32(Console.ReadLine());
                    if (accOperation == 1)
                    {
                        Console.WriteLine("\nСписок сотрудников:");
                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("\nВведите номер нужного сотрудника = ");
                        int accEmplIdx = Convert.ToInt32(Console.ReadLine());
                        Employee accEmpl = employees[accEmplIdx];


                        Console.WriteLine($"\nСотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }
                        
                        Console.WriteLine("\nВведите номер справки = ");
                        int reqId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"\nИнформация по справке:" +
                            $"\n{accEmpl.GetEmployeeRequests()[reqId]}");
                    }
                    if (accOperation == 2)
                    {
                        Console.WriteLine("\nСписок сотрудников:");
                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("\nВведите номер нужного сотрудника = ");
                        int accEmplIdx = Convert.ToInt32(Console.ReadLine());
                        Employee accEmpl = employees[accEmplIdx];


                        Console.WriteLine($"\nСотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }

                        Console.WriteLine("\nВведите номер справки = ");
                        int reqId = Convert.ToInt32(Console.ReadLine());

                        IRequestState currentReqStatus = accEmpl.GetEmployeeRequests()[reqId].GetCertStatus();

                        Console.WriteLine($"\nСправка имеет статус = " +
                            $" {accEmpl.GetEmployeeRequests()[reqId].GetCertStatusName()}");

                        if (currentReqStatus is NewRequest)
                        {
                            Console.WriteLine("\nЕсли вы хотите перевести заявку в статус В работе," +
                                "введите Да");
                            string answer = Console.ReadLine();
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
                                Console.WriteLine("\nВведен неверный ответ. Статус заявки не изменился");
                        }
                        else if (currentReqStatus is RejectedRequest)
                        {
                            Console.WriteLine("\nЕсли вы хотите вернуть заявку в статус В работе," +
                                "введите Да");
                            string answer = Console.ReadLine();
                            if (answer.Equals("Да"))
                            {
                                currentReqStatus.TakeToWork(accEmpl.GetEmployeeRequests()[reqId]);
                            }
                            else
                                Console.WriteLine("\nВведен неверный ответ. Статус заявки не изменился");
                        }
                    }
                    else if (accOperation == 3)
                    {
                        Console.WriteLine($"\nВведите тип требуемой справки(2-НДФЛ,по месту работы, средний доход," +
                            $"свободной формы) :");
                        string reqCertType = Console.ReadLine();
                        CertificateTypes newCertType;
                        switch (reqCertType)
                        {
                            case "2-НДФЛ":
                                newCertType = CertificateTypes.NDFL2;
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
                            default:
                                Console.WriteLine("\nУказан несуществующий тип справки");
                                throw new Exception("Пока не обработал неверный тип справки :С");
                        }

                        Console.WriteLine($"\nВведите кол-во справок для заказа:");
                        int reqCertAmount = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"\nВведите причину заказа справки");
                        string reqCertReason = Console.ReadLine();

                        currentEmpl.RequestCertificate(newCertType, reqCertAmount, reqCertReason);
                    }
                    if (accOperation == 4)
                    {
                        Console.WriteLine($"\nСписок справок сотрудника {currentEmpl.GetName()} :");
                        foreach (Request req in currentEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine(req);
                        }
                    }
                }
            }
            else if(mainMenu == 2)
            {
                //выход из программы
                Environment.Exit(0);
            }
        }
     }
}