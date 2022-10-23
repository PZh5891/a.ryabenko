using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test_CRM
{
    [Serializable]
    internal abstract class Partner
    {
        private readonly string _id;
        private readonly DateTime _createdDate;
        public string Id { get { return _id; } }
        public DateTime CreatedDate { get { return _createdDate; }}
        public DateTime ChangeDate { get; private set; }
        public string CreatedBy { get; private set; }
        protected string _adress;
        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                WhenChanged();
            }
        }

        public abstract string View { get; }

        public virtual string Description
        {
            get
            {
                return String.Format("{0} id: {1} changed: {2}", View, Id, ChangeDate);
            }
        }

        public Partner(string id, string user)
        {
            _id = id;
            CreatedBy = user;
            _createdDate = DateTime.Now;
            WhenChanged();
        }

        protected void WhenChanged()
        {
            ChangeDate = DateTime.Now;
        }
    }
}
