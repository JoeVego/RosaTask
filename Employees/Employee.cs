using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Certificates;
using FirstApp.Requests;

namespace FirstApp.Employees
{
    /// <summary>
    /// Родительский класс сотрудников. Определяет что каждый сотрудник имеет ФИО, должность,
    /// может запросить справку и получить список отправленных запросов
    /// </summary>
    internal abstract class Employee
    {
        public string firstName;
        public EmployeePositions position;
        public List<Request> certRequests;

        protected Employee(string firstName, EmployeePositions position)
        {
            this.firstName = firstName;
            this.position = position;
            this.certRequests = new List<Request>();
        }

        /// <summary>
        /// метод запроса справки сотрудником.
        /// посчитал, что все сотрудники, в том числе и бухгалтер могу запросить справку
        /// </summary>
        public void RequestCertificate(CertificateTypes typeOfCert, int amount, string reason)
        {
            certRequests.Add(new Request(this, typeOfCert, amount, reason));
        }

        public List<Request> GetEmployeeRequests()
        {
            return certRequests;
        }

        public Request GetRequest(int positionInList)
        {
            return certRequests[positionInList];
        }

        public override string ToString()
        {
            return $"{firstName} в должности {position}";
        }
    }
}
