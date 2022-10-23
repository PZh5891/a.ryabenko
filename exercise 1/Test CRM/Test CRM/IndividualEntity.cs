using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CRM
{
    /// <summary>
    /// физическое лицо
    /// </summary>
    [Serializable]
    internal class IndividualEntity : Partner
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                WhenChanged();
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                WhenChanged();
            }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                WhenChanged();
            }
        }

        public override string View { get { return String.Format("{0} {1} {2}", LastName, FirstName, MiddleName); } }

        public IndividualEntity(string id, string user) : base(id, user)
        {
        }
        public IndividualEntity(string id, string user, string lastName, string firstName, string middleName) : base(id, user)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
        }
    }
}
