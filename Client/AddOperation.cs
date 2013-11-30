using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ServiceReference1
{
    partial class AddOperation
    {
        protected bool Equals(AddOperation other)
        {
            return AField == other.AField && BField == other.BField;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddOperation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (AField*397) ^ BField;
            }
        }

        public override string ToString()
        {
            return string.Format("A: {0}, B: {1}", A, B);
        }
    }
}
