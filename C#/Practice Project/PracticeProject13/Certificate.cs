using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject13
{
    internal class Certificate
    {
        public string CertificateID {  get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateTime CertificateDate { get; set; }

        public Certificate(string certificateID, string certificateName, string certificateRank, DateTime certificateDate)
        {
            CertificateID = certificateID;
            CertificateName = certificateName;
            CertificateRank = certificateRank;
            CertificateDate = certificateDate;
        }

        public override string? ToString()
        {
            return CertificateName + ", " + CertificateID + ", " + CertificateRank + ", " + CertificateDate;
        }
    }
}
