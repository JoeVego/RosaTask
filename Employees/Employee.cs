using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Certificates;

namespace FirstApp.Employees
{
    /// <summary>
    /// Родительский класс сотрудников. Определяет что каждый сотрудник имеет ФИО, должность,
    /// может запросить справку и получить список отправленных запросов
    /// </summary>
    internal abstract class Employee
    {
        private string firstName;
        private EmployeePositions position;

        public abstract void RequestCertificate();

        //посчитал, что все сотрудники, в том числе и бухгалтер могу запросить справку
        public abstract Certificate[] GetRequests();
    }
}
