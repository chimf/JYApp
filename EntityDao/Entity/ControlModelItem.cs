using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDao.Entity
{
   public class ControlModelItem
    {
        public ControlModelItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
