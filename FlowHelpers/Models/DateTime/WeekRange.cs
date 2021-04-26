using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowHelpers.Models
{
    public class WeekRangeResponse
    {
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string RangeLabel { get; set; }
	}
	public class WeekRange
    {
        public int WeekOfYear { get; set; }
        public int YearToSearch { get; set; }

        public static WeekRangeResponse ProcessRequest(WeekRange req)
        {
			//var currentDate = DateTime.Today;
			//var currentYear = currentDate.Year;
			var currentYear = req.YearToSearch;
			var weekOfYear = req.WeekOfYear;
			var firstOfYear = new DateTime(currentYear, 1, 1);
			Console.WriteLine("1st of Year: " + firstOfYear.ToLongDateString());

			var firstDayOfYear = firstOfYear.DayOfWeek;
			if (firstDayOfYear.ToString() != "Monday")
			{
				do
				{
					firstOfYear = firstOfYear.AddDays(-1);
					firstDayOfYear = firstOfYear.DayOfWeek;
				}
				while (firstDayOfYear.ToString() != "Monday");
			}

			//Find week;
			
			var daysToAdd = (weekOfYear - 1) * 7;
			var dateRangeStart = firstOfYear.AddDays(daysToAdd);
			var dateRangeEnd = dateRangeStart.AddDays(6);

			var rangeLabel = (dateRangeStart.ToShortDateString() + " - " + (dateRangeEnd.ToShortDateString()));

			WeekRangeResponse response = new WeekRangeResponse();
			response.StartDate = dateRangeStart;
			response.EndDate = dateRangeEnd;
			response.RangeLabel = rangeLabel;

			return response;
		}
    }
}