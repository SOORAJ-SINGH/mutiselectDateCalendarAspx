using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MultiSelectDataCalendar_1
{
    public partial class Index : System.Web.UI.Page
    {
        public static List<DateTime> dateList = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                dateList.Add(e.Day.Date);
                
            }
            Session["SelectedDates"] = dateList;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                dateList.Clear();
            }
        }

        protected void btnClearSelection_Click(object sender, EventArgs e)
        {
            Session["SelectedDates"] = null;
            dateList.Clear();
            Calendar1.SelectedDates.Clear();
           
        }

        protected void btnPrintSelectedTDate_Click(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Response.Write(dt.ToShortDateString() + "<BR/>");
                }
            }
        }
    }
}