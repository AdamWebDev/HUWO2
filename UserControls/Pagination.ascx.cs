using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2.UserControls
{
    public partial class Pagination : System.Web.UI.UserControl
    {
        public int NumberOfItems { get; set; }
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
               
        }
    }
}