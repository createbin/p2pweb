using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data
{
    /// <summary>
    /// Base nopCommerce model
    /// </summary>
    public partial class BaseModel
    {
        public BaseModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Base nopCommerce entity model
    /// </summary>
    public partial class BaseEntityModel : BaseModel
    {
        public virtual int Id { get; set; }
    }
}
