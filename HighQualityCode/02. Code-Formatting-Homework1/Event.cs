using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

internal class Event : IComparable
{
	public Event (DateTime date, String title, String location)
	{
		this.date = date;
		this.title = title;
		this.location = location;
	}

	public DateTime Date { get; set; };
	public String Title { get; set; };
	public String Location { get; set; };

	public int CompareTo(object obj)
	{
		Event other = obj as Event;
		int byDate = this.date.CompareTo(other.date);
		
		if (byDate == 0)
		{
			int byTitle = this.title.CompareTo(other.title);
			if (byTitle == 0)
			{
				int byLocation = this.location.CompareTo(other.location);
				return byLocation;
			}
			else
			{
				return byTitle;
			}
		}
		else
		{
			return byDate;
		}
	}

	public override string ToString()
	{
		StringBuilder toString = new StringBuilder();
		toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
		toString.Append(" | " + title);
		if (location != null && location != "")
		{
			toString.Append(" | " + location);
		}
		return toString.ToString();
	}
}