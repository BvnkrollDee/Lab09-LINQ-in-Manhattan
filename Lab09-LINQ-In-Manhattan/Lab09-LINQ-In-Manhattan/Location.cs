using System;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace Lab09_LINQ_In_Manhattan
{
	public class Geometry
	{
		public string type { get; set; }
        public double[] coordinates { get; set; }
    }


	public class Properties
	{
		public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }
    }

	public class Location
	{

		public string type { get; set; }
		public Geometry geometry { get; set; }
        public Properties properties { get; set; }

    }


	public class FeatureCollection
	{
		public string type { get; set; }
		public Location[] features { get; set; }
    }
}

