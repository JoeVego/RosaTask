using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Employees;

namespace FirstApp.Certificates
{
    /// <summary>
    /// Класс справки содержит информацию о заказчике справки
    /// и ее типе
    /// </summary>
    internal class Certificate
    {
        private CertificateTypes certificateType;
        private Employee employee;

        public Certificate(CertificateTypes certificateType, Employee employee)
        {
            this.certificateType = certificateType;
            this.employee = employee;
        }

        internal CertificateTypes GetCertificateType()
        {
            return certificateType;
        }

        public string GetCertTypeName()
        {
            switch (certificateType)
            {
                case CertificateTypes.NDFL2:
                    return "2-НДФЛ";
                case CertificateTypes.JobPlace:
                    return "по месту работы";
                case CertificateTypes.AverageIncome:
                    return "средний доход";
                case CertificateTypes.FreeType:
                    return "свободной формы";
                default:
                    return "Некорректный тип справки";
            }
        }
    }
}
