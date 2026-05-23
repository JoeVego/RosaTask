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
        private Statuses state;

        public Request(Employee employee, Certificate certificate, int amount, string reason, Statuses state)
        {
            this.employee = employee;
            this.certificate = certificate;
            this.amount = amount;
            this.reason = reason;
            this.state = state;
        }

        // не приват ведь для буха метод
        private void getCertInfo()
        {
            // сделать
        }

        // не приват ведь для буха метод
        private void changeState()
        {
            // меняем статус
        }

        public void SetState(Statuses newState)
        {
            this.state = newState;
        }
    }

}
