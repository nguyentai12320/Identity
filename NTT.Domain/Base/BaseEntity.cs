using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Domain.Base
{
    public class BaseEntity : CoreBaseEntity
    {
        public long ID { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public long CreateBy { get; set; }
        public long UpdateBy { get; set; }
    }
}
