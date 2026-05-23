using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Certificates;
using FirstApp.Employees;

namespace FirstApp.Requests
{
    internal class Request
    {
        private Employee employee;
        private Certificate certificate;
        private int amount;
        private string reason;
        private RequestStatuses status;

        public Request(Employee employee, Certificate certificate, int amount, string reason, RequestStatuses status)
        {
            this.employee = employee;
            this.certificate = certificate;
            this.amount = amount;
            this.reason = reason;
            this.status = status;
        }

        // не приват ведь для буха метод
        private void getCertInfo()
        {
            // сделать
        }

        // не приват ведь для буха метод
        private void changeStatus()
        {
            // меняем статус
        }
    }

}
