using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CRM
{
    /// <summary>
    /// юридическое лицо
    /// </summary>
    [Serializable]
    internal class LegalEntity : Partner
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                WhenChanged();
            }
        }
        public override string View { get { return _title ?? "<empty>"; } }

        public override string Description
        {
            get
            {
                return String.Format("{0} contacts: {1}", base.Description, Contacts.Count());
            }
        }

        public List<IndividualEntity> Contacts { get; set; }
        public LegalEntity(string id, string user) : base(id, user)
        {
            Contacts = new List<IndividualEntity>();
        }
    }
}
