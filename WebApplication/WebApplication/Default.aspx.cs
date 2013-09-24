using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String temp = "<br>Name is " + TextBox1.Text + "<br>";
            temp += "Saved content of previous page is " + ViewState["name"] as String;
            Label1.Text = temp;
        }

        protected override void LoadViewState(object viewState)
        {
            if (viewState != null)
                base.LoadViewState(viewState);
        }

        protected override object SaveViewState()
        {
            ViewState["name"] = TextBox1.Text;
            return base.SaveViewState();
        }
    }
}