using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Employees;

namespace FirstApp.Certificates
{
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

        
    }
}
